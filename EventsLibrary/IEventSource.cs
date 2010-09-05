using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsLibrary
{
    public interface IEventSource : IDisposable
    {
        event EventHandler<ActionsEventArgs> EventRaised;
    }
}
