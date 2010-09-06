using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public sealed class AddEventAction : EventAction
    {
        public AddEventAction(Event addEvent) : base(addEvent)
        {
        }
    }
}
