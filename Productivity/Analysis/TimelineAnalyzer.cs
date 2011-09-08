namespace Productivity.Analysis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using EventsLibrary;
    using Microsoft.CSharp.RuntimeBinder;
    using Productivity.Models;
    using EventFilter = System.Func<System.Predicate<EventsLibrary.DynamicEvent>, EventsLibrary.DynamicEvent>;

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
                         select e.EndTime).Union
                        (new[] { startTime, endTime }).OrderBy(t => t).ToList();

            var spans = times.Zip(times.Skip(1), (start, end) => new { startTime = start, endTime = end }).ToList();

            var segments = new List<TimelineSegment>();

            var rules = this.db.Rules.ToList();

            for (int i = 0; i < spans.Count; i++)
            {
                var span = spans[i];

                TimelineSegment segment = null;

                Func<Predicate<DynamicEvent>, DynamicEvent> mostRecent = predicate =>
                {
                    return (from e in events
                            where e.StartTime <= span.startTime
                            where predicate(e)
                            orderby e.StartTime descending
                            select e).FirstOrDefault();
                };


                foreach (var rule in rules)
                {
                    var result = RunRule(rule, span.startTime, span.endTime, events, mostRecent);

                    if (result != null)
                    {
                        if (result.StartTime > span.startTime)
                        {
                            spans.Add(new { startTime = span.startTime, endTime = result.StartTime });
                        }

                        if (result.EndTime < span.endTime)
                        {
                            spans.Add(new { startTime = result.EndTime, endTime = span.endTime });
                        }

                        segment = result;
                        break;
                    }
                }

                if (segment != null)
                {
                    segments.Add(segment);
                }
            }

            Simplify(segments);
            return segments;
        }

        private void Simplify(List<TimelineSegment> segments)
        {
            segments.Sort((a, b) => a.StartTime.CompareTo(b.StartTime));

            int i = 0;
            while (i < segments.Count - 1)
            {
                var a = segments[i];
                var b = segments[i + 1];

                if (a.EndTime == b.StartTime &&
                    a.Description == b.Description &&
                    a.Productivity == b.Productivity)
                {
                    a.EndTime = b.EndTime;
                    segments.RemoveAt(i + 1);
                }
                else
                {
                    i++;
                }
            }
        }

        private TimelineSegment RunRule(Rule rule, DateTime startTime, DateTime endTime, IList<DynamicEvent> events, EventFilter mostRecent)
        {
            var ruleFunc = ScriptManager.GetScriptFunc(rule.Expression);
            dynamic result;
            try
            {
                result = ruleFunc(startTime, endTime, events, mostRecent);
            }
            catch (TargetInvocationException)
            {
                // TODO: This should be bubbled up, so that the user can be notified of which rule cause the error.
                return null;
            }

            if (result == null)
            {
                return null;
            }
            else if (result is bool)
            {
                return !result
                    ? null
                    : new TimelineSegment
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
                ruleResult.Description = ruleResult.Description ?? "";
                if (ruleResult.Productivity.HasValue)
                {
                    ruleResult.Productivity = Clamp(ruleResult.Productivity.Value, 0, 100);
                }

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
