using System;
using System.Security.Permissions;
using System.Linq;
using System.Windows.Forms;
using Productivity.StandardPlugins;
using EventsLibrary;
using System.Collections.Generic;

namespace Productivity
{
    public partial class CollectionForm : Form
    {
        private List<IEventSource> sources = new List<IEventSource>();
        private EventHandler<ActionsEventArgs> eventRaisedHandle;

        private Queue<IList<EventAction>> actionQueue = new Queue<IList<EventAction>>();
        private Dictionary<Event, Guid> eventIds = new Dictionary<Event, Guid>();

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public CollectionForm()
        {
            InitializeComponent();

            this.eventRaisedHandle = new EventHandler<ActionsEventArgs>(this.Source_EventRaised);

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

        private void QueueProcessTimer_Tick(object sender, EventArgs e)
        {
            while (true)
            {
                IList<EventAction> actions = null;

                lock (this.actionQueue)
                {
                    if (this.actionQueue.Count == 0)
                    {
                        break;
                    }

                    actions = this.actionQueue.Dequeue();
                }

                this.ProcessActions(actions);
            }
        }

        private void ProcessActions(IList<EventAction> actions)
        {
            using (var db = new Models.EventsConnection())
            {
                foreach (var action in actions)
                {
                    if (action is AddEventAction)
                    {
                        var @event = (action as AddEventAction).Event;

                        if (!this.eventIds.ContainsKey(@event))
                        {
                            var id = Guid.NewGuid();

                            var newEvent = new Models.Event
                            {
                                EventId = id.ToString(),
                                Time = @event.Time.UtcDateTime,
                                Duration = @event.Duration.ToString(),
                                Type = @event.Type.Name
                            };

                            db.Events.AddObject(newEvent);

                            this.eventIds.Add(@event, id);
                        }
                    }
                    else if (action is RemoveEventAction)
                    {
                        var @event = (action as RemoveEventAction).Event;

                        if (this.eventIds.ContainsKey(@event))
                        {
                            var id = this.eventIds[@event];

                            var oldEvent = db.Events.Where(e => e.EventId == id.ToString()).Single();
                            db.Events.DeleteObject(oldEvent);

                            this.eventIds.Remove(@event);
                        }
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
