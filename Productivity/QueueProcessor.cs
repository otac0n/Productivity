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
            this.processThread.Name = "Queue Processor";
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
            while (true)
            {
                IList<EventAction> actions = new List<EventAction>();

                lock (this.actionQueue)
                {
                    if (!this.running && this.actionQueue.Count == 0)
                    {
                        break;
                    }

                    while (this.actionQueue.Count == 0 && this.running)
                    {
                        Monitor.Wait(this.actionQueue);
                    }

                    while (this.actionQueue.Count != 0)
                    {
                        foreach (var action in this.actionQueue.Dequeue())
                        {
                            actions.Add(action);
                        }
                    }
                }

                Debug.WriteLine("Moved " + actions.Count + " actions from main queue into worker queue.");
                actions = this.SimplifyActions(actions);
                Debug.WriteLine("Simplified to " + actions.Count + " actions.");

                this.ProcessActions(actions);
            }
        }

        private IList<EventAction> SimplifyActions(IList<EventAction> actions)
        {
            var set = new Dictionary<Guid, EventAction>();

            foreach (var action in actions)
            {
                set[action.Id] = action;
            }

            return set.Values.ToList();
        }

        private void ProcessActions(IList<EventAction> actions)
        {
            lock (this.db)
            {
                foreach (var action in actions)
                {
                    var oldEvent = db.Events.Where(e => e.EventId == action.Id).SingleOrDefault();

                    if (action is UpdateEventAction)
                    {
                        var data = (action as UpdateEventAction).EventData;

                        if (oldEvent == null)
                        {
                            var newEvent = new Models.Event
                            {
                                EventId = action.Id,
                                Time = data.Time.UtcDateTime,
                                Duration = data.Duration.ToString(),
                                Type = data.Type.Name,
                                Data = data.Data,
                            };

                            db.Events.AddObject(newEvent);
                        }
                        else
                        {
                            oldEvent.Time = data.Time.UtcDateTime;
                            oldEvent.Duration = data.Duration.ToString();
                            oldEvent.Type = data.Type.Name;
                            oldEvent.Data = data.Data;
                        }
                    }
                    else if (action is RemoveEventAction)
                    {
                        if (oldEvent != null)
                        {
                            db.Events.DeleteObject(oldEvent);
                        }
                        else
                        {
                            // Take no action.
                        }
                    }

                    db.SaveChanges(SaveOptions.AcceptAllChangesAfterSave);
                }
            }
        }
    }
}
