namespace EventsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class EventAction
    {
        private Guid id;

        public EventAction(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("id");
            }

            this.id = id;
        }

        public Guid Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}
