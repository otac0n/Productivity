using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public sealed class AddEventAction : EventAction
    {
        private Event addEvent;

        public AddEventAction(Event addEvent)
        {
            if (addEvent == null)
            {
                throw new ArgumentNullException("addEvent");
            }

            this.addEvent = addEvent;
        }

        public Event Event
        {
            get
            {
                return addEvent;
            }
            set
            {
                addEvent = value;
            }
        }
    }
}
