namespace Productivity.Analysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Productivity.Models;

    public class TimelineAnalyzer
    {
        private EventsConnection db;

        public TimelineAnalyzer(EventsConnection db)
        {
            this.db = db;
        }

        internal void Analyze(DateTime startTime, DateTime endTime)
        {
            var events = (from e in this.db.Events
                          where e.EndTime >= startTime
                          where e.StartTime <= endTime
                          select e).ToList();

            var times = new HashSet<DateTime>();
            foreach (var e in events)
            {
                times.Add(e.StartTime);
                times.Add(e.EndTime);
            }
        }
    }
}
