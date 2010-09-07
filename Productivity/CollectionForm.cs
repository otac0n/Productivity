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

            var keyboard = new KeyboardActivitySource("10");
            keyboard.EventRaised += this.Source_EventRaised;
            this.sources.Add(keyboard);

            var mouse = new MouseActivitySource("3");
            mouse.EventRaised += this.Source_EventRaised;
            this.sources.Add(mouse);
        }

        private void Source_EventRaised(object sender, ActionsEventArgs e)
        {
            lock (this.actionQueue)
            {
                this.actionQueue.Enqueue(e.Actions);
                Monitor.PulseAll(this.actionQueue);
            }
        }

        private string prev = null;

        private void SetStatus(string status)
        {
            if (status != prev)
            {
                this.textBox1.AppendText(status + "\r\n");
                prev = status;
            }
        }

        private void SnapshotTimer_Tick(object sender, EventArgs e)
        {
            var info = UserContext.GetUserContextInfo();
            if (info != null)
            {
                SetStatus(info.FileName + ":" + info.ProcessId + " (" + info.Title + ") [" + info.HWnd + "]" + (string.IsNullOrEmpty(info.Location) ? string.Empty : "\r\n" + info.Location));
            }
        }
    }
}
