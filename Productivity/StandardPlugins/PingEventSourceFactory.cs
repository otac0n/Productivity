using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;

namespace Productivity.StandardPlugins
{
    public class PingEventSourceFactory : IEventSourceFactory
    {
        public string Name
        {
            get
            {
                return "Ping";
            }
        }

        public IEventSource CreateInstance(string settings)
        {
            return new PingEventSource(settings);
        }

        public string Configure(string currentSettings)
        {
            return currentSettings;
        }
    }
}
