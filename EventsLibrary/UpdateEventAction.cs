using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public sealed class UpdateEventAction : EventAction
    {
        private readonly EventData eventData;

        public UpdateEventAction(Guid id, EventData eventData) : base(id)
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
