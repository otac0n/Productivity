using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public sealed class RemoveEventAction : EventAction
    {
        private Event removeEvent;

        public RemoveEventAction(Event removeEvent)
        {
            if (removeEvent == null)
            {
                throw new ArgumentNullException("removeEvent");
            }

            this.removeEvent = removeEvent;
        }

        public Event Event
        {
            get
            {
                return removeEvent;
            }
            set
            {
                removeEvent = value;
            }
        }
    }
}
