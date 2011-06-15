using System;
using System.Security.Permissions;
using System.Linq;
using System.Windows.Forms;
using Productivity.StandardPlugins;
using EventsLibrary;
using System.Collections.Generic;
using System.Data.Objects;
using System.Threading;
using System.Reflection;
using System.IO;

namespace Productivity
{
    public partial class CollectionForm : Form
    {
        private List<IEventSource> sources = new List<IEventSource>();
        private Queue<IList<EventAction>> actionQueue = new Queue<IList<EventAction>>();
        private Models.EventsConnection db = new Models.EventsConnection();
        private QueueProcessor processor;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public CollectionForm()
        {
            var dir = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Plugins");
            var plugins = PluginLoader.LoadAllPlugins(dir);

            this.processor = new QueueProcessor(this.actionQueue, this.db);

            InitializeComponent();

            var ping = new PingEventSource("1");
            ping.EventRaised += this.Source_EventRaised;
            this.sources.Add(ping);

            var sys = new SystemStatusSource(null);
            sys.EventRaised += this.Source_EventRaised;
            this.sources.Add(sys);

            var kbd = new KeyboardActivitySource(null);
            kbd.EventRaised += this.Source_EventRaised;
            this.sources.Add(kbd);

            var mos = new MouseActivitySource(null);
            mos.EventRaised += this.Source_EventRaised;
            this.sources.Add(mos);

            foreach (var plugin in from p in plugins
                                    let evt = p as IEventSourceFactory
                                    where evt != null
                                    select evt)
            {
                var p = plugin.CreateInstance(string.Empty);
                p.EventRaised += this.Source_EventRaised;
                this.sources.Add(p);
            }
        }

        private void Source_EventRaised(object sender, ActionsEventArgs e)
        {
            lock (this.actionQueue)
            {
                this.actionQueue.Enqueue(e.Actions.ToArray());
                Monitor.PulseAll(this.actionQueue);
            }
        }

        private void CollectionForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
