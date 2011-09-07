using System;

namespace Productivity.Analysis
{
    internal class TimelineSegment
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int Productivity { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2}%): {3}", this.StartTime, this.EndTime, this.Productivity, this.Description);
        }
    }
}
