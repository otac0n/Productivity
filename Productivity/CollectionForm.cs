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
        private EventHandler<ActionsEventArgs> eventRaisedHandle;

        private Queue<IList<EventAction>> actionQueue = new Queue<IList<EventAction>>();
        private Thread queueProcessThread;
        private Models.EventsConnection db = new Models.EventsConnection();

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public CollectionForm()
        {
            InitializeComponent();

            this.eventRaisedHandle = new EventHandler<ActionsEventArgs>(this.Source_EventRaised);

            this.queueProcessThread = new Thread(new ThreadStart(this.QueueProcessTimer_Tick));
            this.queueProcessThread.IsBackground = true;
            this.queueProcessThread.Start();

            var ping = new PingEventSource("1");
            ping.EventRaised += this.eventRaisedHandle;
            this.sources.Add(ping);

            var keyboard = new KeyboardActivitySource("10");
            keyboard.EventRaised += this.eventRaisedHandle;
            this.sources.Add(keyboard);

            var mouse = new MouseActivitySource("3");
            mouse.EventRaised += this.eventRaisedHandle;
            this.sources.Add(mouse);
        }

        private void Source_EventRaised(object sender, ActionsEventArgs e)
        {
            lock (this.actionQueue)
            {
                this.actionQueue.Enqueue(e.Actions);
                Monitor.Pulse(this.actionQueue);
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

        private void QueueProcessTimer_Tick()
        {
            while (true)
            {
                IList<EventAction> actions = null;

                lock (this.actionQueue)
                {
                    while (this.actionQueue.Count == 0)
                    {
                        Monitor.Wait(this.actionQueue);
                    }

                    actions = this.actionQueue.Dequeue();
                }

                this.ProcessActions(actions);
            }
        }

        private void ProcessActions(IList<EventAction> actions)
        {
            lock (this.db)
            {
                foreach (var action in actions)
                {
                    var @event = action.Event;

                    if (action is AddEventAction)
                    {
                        var newEvent = new Models.Event
                        {
                            EventId = @event.Id,
                            Time = @event.Time.UtcDateTime,
                            Duration = @event.Duration.ToString(),
                            Type = @event.Type.Name,
                            Data = @event.Data,
                        };

                        db.Events.AddObject(newEvent);
                    }
                    else if (action is RemoveEventAction)
                    {
                        var oldEvent = db.Events.Where(e => e.EventId == @event.Id).Single();
                        db.Events.DeleteObject(oldEvent);
                    }

                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
            }
        }
    }
}
