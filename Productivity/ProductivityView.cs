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
        private EventsConnection db;

        public ProductivityView()
        {
            this.db = new EventsConnection();
            InitializeComponent();

            var startTime = DateTime.Today.ToUniversalTime();
            this.productivityBar.StartTime = startTime;
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
            var ruleManager = new RuleManager(this.db);
            ruleManager.ShowDialog(this);
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

            var timelineAnalyzer = new TimelineAnalyzer(this.db);
            e.Result = timelineAnalyzer.Analyze(startTime, endTime);
        }

        private void analysisWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;

            if (e.Error == null)
            {
                var result = (List<TimelineSegment>)e.Result;
                this.productivityBar.Segments = result;
            }
        }

        private void ProductivityView_Shown(object sender, EventArgs e)
        {
            RefreshAnalysis();
        }
    }
}
