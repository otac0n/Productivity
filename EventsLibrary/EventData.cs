﻿namespace EventsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EventData
    {
        private readonly DateTimeOffset time;
        private readonly TimeSpan duration;
        private readonly string data;
        private readonly Type type;

        public EventData(DateTimeOffset time, TimeSpan duration, string data, Type type)
        {
            this.time = time;
            this.duration = duration;
            this.data = data;
            this.type = type;
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
                return this.data;
            }
        }

        public Type Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
