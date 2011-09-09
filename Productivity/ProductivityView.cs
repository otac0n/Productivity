namespace Productivity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Productivity.Models;
    using Productivity.Analysis;

    public partial class ProductivityView : Form
    {
        public ProductivityView()
        {
            InitializeComponent();

            var startTime = DateTime.Today.ToUniversalTime();
            this.productivityBar.StartTime = startTime;
        }

        private void ProductivityView_Shown(object sender, EventArgs e)
        {
            RefreshAnalysis();
        }

        private void ProductivityView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void manageRulesButton_Click(object sender, EventArgs e)
        {
            using (var db = new EventsConnection())
            {
                var ruleManager = new RuleManager(db);
                ruleManager.ShowDialog(this);
            }

            RefreshAnalysis();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshAnalysis();
        }

        private void RefreshAnalysis()
        {
            if (this.Enabled)
            {
                this.Enabled = false;
                this.analysisWorker.RunWorkerAsync();
            }
        }

        private void analysisWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var startTime = this.productivityBar.StartTime;
            var endTime = startTime + this.productivityBar.TimeSpan;

            using (var db = new EventsConnection())
            {
                var timelineAnalyzer = new TimelineAnalyzer(db);
                e.Result = timelineAnalyzer.Analyze(startTime, endTime);
            }
        }

        private void analysisWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                var result = (List<TimelineSegment>)e.Result;
                this.productivityBar.Segments = result;

                var score = CalculateOverall(result);
                this.scoreLabel.Text = score.Item1.ToString("P");
                this.timeScoredLabel.Text = FormatTime(score.Item2);

                this.unclassifiedEventsList.Items.Clear();
                this.unclassifiedEventsList.Groups.Clear();
                var unclassified = result.Where(s => s.IsUnclassified).ToList();
                if (unclassified.Count > 0)
                {
                    var startTime = unclassified.Min(s => s.StartTime);
                    var endTime = unclassified.Max(s => s.EndTime);

                    HashSet<Event> events;
                    using (var db = new EventsConnection())
                    {
                        events = new HashSet<Event>(db.Events.Where(s => s.EndTime > startTime && s.StartTime < endTime));
                    }

                    var unclassifiedEvents = new HashSet<Event>();
                    foreach (var segment in unclassified)
                    {
                        foreach (var evt in events.Where(s => s.EndTime > segment.StartTime && s.StartTime < segment.EndTime).ToList())
                        {
                            unclassifiedEvents.Add(evt);
                            events.Remove(evt);
                        }
                    }

                    var groups = new Dictionary<string, ListViewGroup>();
                    foreach (var evt in unclassifiedEvents.OrderBy(evt => evt.StartTime))
                    {
                        ListViewGroup group;
                        if (!groups.TryGetValue(evt.Type, out group))
                        {
                            group = new ListViewGroup(evt.Type);
                            this.unclassifiedEventsList.Groups.Add(group);
                            groups.Add(evt.Type, group);
                        }

                        var item = new ListViewItem(new[] { evt.StartTime.ToString(), evt.EndTime.ToString(), evt.Data }, group);
                        this.unclassifiedEventsList.Items.Add(item);
                    }
                }
            }

            this.Enabled = true;
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            var sb = new StringBuilder();
            bool shown = false;

            if (timeSpan.Days > 0)
            {
                sb.Append(timeSpan.Days + " days");
                shown = true;
            }

            if (shown || timeSpan.Hours > 0)
            {
                sb.Append((shown ? ", " : "") + timeSpan.Hours + " hrs");
                shown = true;
            }

            sb.Append((shown ? ", " : "") + timeSpan.Minutes + " min");

            return sb.ToString();
        }

        private Tuple<double, TimeSpan> CalculateOverall(List<TimelineSegment> segments)
        {
            var productiveMs = 0.0;
            var unproductiveMs = 0.0;

            foreach (var segment in segments)
            {
                if (segment.Productivity.HasValue)
                {
                    var segmentMs = (segment.EndTime - segment.StartTime).TotalMilliseconds;
                    var productivePortion = segmentMs * (segment.Productivity.Value / 100.0);
                    var unproductivePortion = segmentMs - productivePortion;

                    productiveMs += productivePortion;
                    unproductiveMs += unproductivePortion;
                }
            }

            var totalMs = productiveMs + unproductiveMs;

            var productivityScore = totalMs == 0.0 ? 0.0 : productiveMs / totalMs;
            var timeScored = TimeSpan.FromMilliseconds(totalMs);

            return Tuple.Create(productivityScore, timeScored);
        }
    }
}
