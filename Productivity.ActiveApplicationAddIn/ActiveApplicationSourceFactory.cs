using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;

namespace Productivity.ActiveApplicationAddIn
{
    public class ActiveApplicationSourceFactory : IEventSourceFactory
    {
        public string Name
        {
            get { return "Active Application"; }
        }

        public IEventSource CreateInstance(string settings)
        {
            return new ActiveApplicationSource(settings);
        }

        public string Configure(string currentSettings)
        {
            return currentSettings;
        }
    }
}
