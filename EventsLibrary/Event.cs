using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public class Event
    {
        private readonly DateTimeOffset time;
        private readonly TimeSpan duration;
        private readonly string data;

        public Event(DateTimeOffset time, TimeSpan duration, string data)
        {
            this.time = time;
            this.duration = duration;
            this.data = data;
        }

        public DateTimeOffset Time
        {
            get
            {
                return this.time;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
        }

        public string Data
        {
            get
            {
                return data;
            }
        }
    }
}
