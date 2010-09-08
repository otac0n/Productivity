using System;
using System.Security.Permissions;
using System.Linq;
using System.Windows.Forms;
using Productivity.StandardPlugins;
using EventsLibrary;
using System.Collections.Generic;
using System.Data.Objects;
using System.Threading;

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
            this.processor = new QueueProcessor(this.actionQueue, this.db);

            InitializeComponent();

            var ping = new PingEventSource("1");
            ping.EventRaised += this.Source_EventRaised;
            this.sources.Add(ping);

            //var keyboard = new KeyboardActivitySource("10");
            //keyboard.EventRaised += this.Source_EventRaised;
            //this.sources.Add(keyboard);

            //var mouse = new MouseActivitySource("3");
            //mouse.EventRaised += this.Source_EventRaised;
            //this.sources.Add(mouse);

            //var sys = new SystemStatusSource();
            //sys.EventRaised += this.Source_EventRaised;
            //this.sources.Add(sys);

            var app = new ActiveApplicationSource();
            app.EventRaised += this.Source_EventRaised;
            this.sources.Add(app);
        }

        private void Source_EventRaised(object sender, ActionsEventArgs e)
        {
            lock (this.actionQueue)
            {
                this.actionQueue.Enqueue(e.Actions.ToList().AsReadOnly());
                Monitor.PulseAll(this.actionQueue);
            }
        }
    }
}
