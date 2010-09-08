using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public sealed class AddEventAction : EventAction
    {
        private readonly EventData eventData;

        public AddEventAction(Guid id, EventData eventData) : base(id)
        {
            if (eventData == null)
            {
                throw new ArgumentNullException("eventData");
            }

            this.eventData = eventData;
        }

        public EventData EventData
        {
            get
            {
                return this.eventData;
            }
        }
    }
}
