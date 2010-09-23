namespace EventsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public sealed class RemoveEventAction : EventAction
    {
        public RemoveEventAction(Guid id) : base(id)
        {
        }
    }
}
