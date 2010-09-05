namespace Productivity.StandardPlugins
{
    using System;
    using EventsLibrary;
    using System.Threading;
    using System.Collections.Generic;

    public sealed class PingEventSource : IEventSource
    {
        private readonly DateTimeOffset startTime;

        private Event previousRunningEvent;
        private Event previousTerminatedEvent;

        private Timer timer;

        private bool disposed = false;

        public event EventHandler<ActionsEventArgs> EventRaised;


        public PingEventSource(string settings)
        {
            int seconds = 0;
            seconds = int.TryParse(settings, out seconds) ? seconds : 60;

            startTime = DateTimeOffset.UtcNow;

            this.timer = new Timer(Callback, null, TimeSpan.Zero, TimeSpan.FromSeconds(seconds));
        }

        private void Callback(object state)
        {
            lock (this)
            {
                if (this.EventRaised != null)
                {
                    var actions = GetActions(exitMessage: "Application Terminated Unexpectedly");

                    this.EventRaised(this, new ActionsEventArgs(actions));
                }
            }
        }

        private IList<EventAction> GetActions(string exitMessage)
        {
            var now = DateTimeOffset.UtcNow;
            var newRunningEvent = new Event(this.startTime, now - this.startTime, "Application Running");
            var newTerminatedEvent = new Event(now, TimeSpan.Zero, exitMessage);

            var actions = new List<EventAction>();
            actions.Add(new AddEventAction(newRunningEvent));
            actions.Add(new AddEventAction(newTerminatedEvent));

            if (this.previousRunningEvent != null)
            {
                actions.Add(new RemoveEventAction(this.previousRunningEvent));
                actions.Add(new RemoveEventAction(this.previousTerminatedEvent));
            }

            this.previousRunningEvent = newRunningEvent;
            this.previousTerminatedEvent = newTerminatedEvent;

            return actions;
        }

        public void Dispose()
        {
            lock (this)
            {
                if (!this.disposed)
                {
                    this.disposed = true;

                    timer.Dispose();
                    timer = null;

                    if (this.EventRaised != null)
                    {
                        var actions = GetActions(exitMessage: "Application Exited");

                        this.EventRaised(this, new ActionsEventArgs(actions));
                    }
                }
            }
        }
    }
}
