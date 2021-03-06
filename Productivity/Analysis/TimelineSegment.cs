﻿using System;

namespace Productivity.Analysis
{
    public class TimelineSegment
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int? Productivity { get; set; }

        public bool IsUnclassified { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} ({2}): {3}", this.StartTime.ToLocalTime(), this.EndTime.ToLocalTime(), this.Productivity.HasValue ? this.Productivity.ToString() + "%" : "untracked", this.Description);
        }
    }
}
