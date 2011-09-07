namespace Productivity.Analysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EventsLibrary;
    using Microsoft.CSharp.RuntimeBinder;
    using Productivity.Models;

    public class TimelineAnalyzer
    {
        private EventsConnection db;

        public TimelineAnalyzer(EventsConnection db)
        {
            this.db = db;
        }

        internal List<TimelineSegment> Analyze(DateTime startTime, DateTime endTime)
        {
            var events = (from e in this.db.Events
                          where e.EndTime >= startTime
                          where e.StartTime <= endTime
                          select e)
                         .AsEnumerable()
                         .Select(e => new DynamicEvent(e.StartTime, e.EndTime, e.Data, e.Type))
                         .ToList();

            var times = (from e in events
                         select e.StartTime).Union
                        (from e in events
                         select e.EndTime).OrderBy(t => t).ToList();

            var spans = times.Zip(times.Skip(1), (start, end) => new { startTime = start, endTime = end }).ToList();

            var segments = new List<TimelineSegment>();

            for (int i = 0; i < spans.Count; i++)
            {
                var span = spans[i];

                TimelineSegment segment = null;

                foreach (var rule in this.db.Rules)
                {
                    var result = RunRule(rule, span.startTime, span.endTime, events);

                    if (result != null)
                    {
                        // TODO: Segment the time before and after the result and add it into the list of segments that is being processed.
                        segment = result;
                        break;
                    }
                }

                if (segment != null)
                {
                    segments.Add(segment);
                }
            }

            return segments;
        }

        private TimelineSegment RunRule(Rule rule, DateTime startTime, DateTime endTime, IList<DynamicEvent> events)
        {
            var ruleFunc = ScriptManager.GetScriptFunc(rule.Expression);
            var result = ruleFunc(startTime, endTime, events);

            if (result == null || result == false)
            {
                return null;
            }
            else if (result == true)
            {
                return new TimelineSegment
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    Description = rule.Description,
                    Productivity = rule.Productivity,
                };
            }
            else if (result is string)
            {
                return new TimelineSegment
                {
                    StartTime = startTime,
                    EndTime = endTime,
                    Description = result as string,
                    Productivity = rule.Productivity,
                };
            }
            else
            {
                var ruleResult = new TimelineSegment();

                try { ruleResult.Description = result.Description; }
                catch (RuntimeBinderException) { ruleResult.Description = rule.Description; }

                try { ruleResult.Productivity = result.Productivity; }
                catch (RuntimeBinderException) { ruleResult.Productivity = rule.Productivity; }

                try { ruleResult.StartTime = result.StartTime; }
                catch (RuntimeBinderException) { ruleResult.StartTime = startTime; }

                try { ruleResult.EndTime = result.EndTime; }
                catch (RuntimeBinderException) { ruleResult.EndTime = endTime; }

                ruleResult.StartTime = Clamp(ruleResult.StartTime, startTime, endTime);
                ruleResult.EndTime = Clamp(ruleResult.EndTime, startTime, endTime);
                ruleResult.Productivity = Clamp(ruleResult.Productivity, 0, 100);
                ruleResult.Description = ruleResult.Description ?? "";

                if (ruleResult.StartTime >= ruleResult.EndTime)
                {
                    return null;
                }

                return ruleResult;
            }
        }

        private TValue Clamp<TValue>(TValue value, TValue minValue, TValue maxValue) where TValue : struct, IComparable<TValue>
        {
            if (value.CompareTo(minValue) <= 0)
            {
                return minValue;
            }

            if (value.CompareTo(maxValue) >= 0)
            {
                return maxValue;
            }

            return value;
        }
    }
}
