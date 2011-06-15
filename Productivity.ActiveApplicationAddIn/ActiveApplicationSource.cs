using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using Microsoft.Win32;
using System.Threading;

namespace Productivity.ActiveApplicationAddIn
{
    public sealed class ActiveApplicationSource : IEventSource
    {
        private Timer timer;
        private Guid lastId = Guid.Empty;
        private EventData lastData = null;

        public event EventHandler<ActionsEventArgs> EventRaised;

        public ActiveApplicationSource(string settings)
        {
            this.timer = new Timer(SnapshotTimer_Tick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void SnapshotTimer_Tick(object state)
        {
            var now = DateTimeOffset.UtcNow;
            var actions = new List<EventAction>();
            UpdateLastTick(now, actions);

            var info = UserContext.GetUserContextInfo();
            if (info != null)
            {
                var data = DataSerializer.Serialize(info);
                UpdateCurrentTick(now, data, actions);
            }
            else
            {
                UpdateCurrentTick(now, null, actions);
            }

            if (this.EventRaised != null && actions.Count > 0)
            {
                this.EventRaised(this, new ActionsEventArgs(actions));
            }
        }

        private void UpdateLastTick(DateTimeOffset now, List<EventAction> actions)
        {
            if (this.lastData != null)
            {
                actions.Add(new UpdateEventAction(
                    this.lastId,
                    new EventData(this.lastData.Time, now - this.lastData.Time, this.lastData.Data, this.GetType())));
            }
        }

        private void UpdateCurrentTick(DateTimeOffset now, string data, List<EventAction> actions)
        {
            if (data == null)
            {
                this.lastData = null;
            }
            else if (this.lastData == null || this.lastData.Data != data)
            {
                this.lastId = Guid.NewGuid();
                this.lastData = new EventData(now, TimeSpan.Zero, data, this.GetType());

                actions.Add(new UpdateEventAction(
                    this.lastId,
                    this.lastData));
            }
        }

        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Dispose();
                this.timer = null;
            }
        }
    }
}
