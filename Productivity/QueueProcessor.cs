using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using Productivity.Models;
using System.Threading;
using System.Data.Objects;
using System.Diagnostics;

namespace Productivity
{
    public class QueueProcessor : IDisposable
    {
        private Queue<IList<EventAction>> actionQueue;
        private EventsConnection db;

        private Thread processThread;
        private bool running = true;

        public QueueProcessor(Queue<IList<EventAction>> actionQueue, EventsConnection db)
        {
            if (actionQueue == null)
            {
                throw new ArgumentNullException("actionQueue");
            }

            this.actionQueue = actionQueue;

            if (db == null)
            {
                throw new ArgumentNullException("db");
            }

            this.db = db;

            this.processThread = new Thread(this.Run);
            this.processThread.IsBackground = true;
            this.processThread.Start();
        }

        public void Dispose()
        {
            lock (this.actionQueue)
            {
                this.running = false;
                Monitor.PulseAll(this.actionQueue);
            }

            this.processThread.Join();
        }

        private void Run()
        {
            while (this.running)
            {
                IList<EventAction> actions = null;

                lock (this.actionQueue)
                {
                    while (this.actionQueue.Count == 0 && this.running)
                    {
                        Monitor.Wait(this.actionQueue);
                    }

                    if (this.running)
                    {
                       actions = this.actionQueue.Dequeue();
                    }
                }

                if (actions != null)
                {
                    this.ProcessActions(actions);
                }
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
                        Debug.WriteLine("+ " + @event.Id.ToString());

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
                        Debug.WriteLine("- " + @event.Id.ToString());

                        var oldEvent = db.Events.Where(e => e.EventId == @event.Id).Single();
                        db.Events.DeleteObject(oldEvent);
                    }

                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
            }
        }
    }
}
