using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;

namespace Productivity.ActiveApplicationAddIn
{
    public class AssemblyPluginEnumerator : IPluginEnumerator
    {
        public IEnumerable<IPluginFactory> EnumerateFactories()
        {
            yield return new ActiveApplicationSourceFactory();
        }
    }
}
