using System;
using System.Security.Permissions;
using System.Linq;
using System.Windows.Forms;
using Productivity.StandardPlugins;
using EventsLibrary;
using System.Collections.Generic;
using System.Data.Objects;

namespace Productivity
{
    public partial class CollectionForm : Form
    {
        private List<IEventSource> sources = new List<IEventSource>();
        private EventHandler<ActionsEventArgs> eventRaisedHandle;

        private Queue<IList<EventAction>> actionQueue = new Queue<IList<EventAction>>();
        private System.Threading.Timer queueProcessTimer;
        private Models.EventsConnection db = new Models.EventsConnection();

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public CollectionForm()
        {
            InitializeComponent();

            this.eventRaisedHandle = new EventHandler<ActionsEventArgs>(this.Source_EventRaised);

            this.queueProcessTimer = new System.Threading.Timer(this.QueueProcessTimer_Tick, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));

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

        private void QueueProcessTimer_Tick(object state)
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

        private bool ValidateQueue()
        {
            HashSet<Guid> events = new HashSet<Guid>();

            foreach (var item in this.actionQueue)
            {
                foreach (var action in item)
                {
                    var @event = action.Event;

                    if (action is AddEventAction)
                    {
                        if (events.Contains(@event.Id))
                        {
                            return false;
                        }
                        else
                        {
                            events.Add(@event.Id);
                        }
                    }
                    else if (action is RemoveEventAction)
                    {
                        if (!events.Contains(@event.Id))
                        {
                            return false;
                        }
                        else
                        {
                            events.Remove(@event.Id);
                        }
                    }
                }
            }

            return true;
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
                        var id = Guid.NewGuid().ToString();

                        var newEvent = new Models.Event
                        {
                            EventId = @event.Id.ToString(),
                            Time = @event.Time.UtcDateTime,
                            Duration = @event.Duration.ToString(),
                            Type = @event.Type.Name,
                            Data = @event.Data,
                        };

                        db.Events.AddObject(newEvent);
                    }
                    else if (action is RemoveEventAction)
                    {
                        var id = @event.Id.ToString();
                        var oldEvent = db.Events.Where(e => e.EventId == id).Single();
                        db.Events.DeleteObject(oldEvent);
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
