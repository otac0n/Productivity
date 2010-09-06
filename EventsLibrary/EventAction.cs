using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public abstract class EventAction
    {
        private Event @event;

        public EventAction(Event @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            this.@event = @event;
        }

        public Event Event
        {
            get
            {
                return this.@event;
            }
            set
            {
                this.@event = value;
            }
        }
    }
}
