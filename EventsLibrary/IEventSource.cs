namespace EventsLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IEventSource : IDisposable
    {
        event EventHandler<ActionsEventArgs> EventRaised;
    }
}
