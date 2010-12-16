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

        public event EventHandler<ActionsEventArgs> EventRaised;

        public ActiveApplicationSource(string settings)
        {
            this.timer = new Timer(SnapshotTimer_Tick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void SnapshotTimer_Tick(object state)
        {
            var e = this.EventRaised;
            if (e != null)
            {
                var info = UserContext.GetUserContextInfo();
                if (info != null)
                {
                    var data = "Active Application: " + info.Title + "\n" +
                        "hWnd: " + info.HWnd + "\n" +
                        "Filename: " + info.FileName + "\n" +
                        "Location: " + info.Location + "\n" +
                        "Process: " + info.ProcessId;

                    var currentData = new EventData(DateTime.UtcNow, TimeSpan.Zero, data, this.GetType());
                    var actions = new List<EventAction>() {
                        new UpdateEventAction(Guid.NewGuid(), currentData),
                    };
                    e(this, new ActionsEventArgs(actions));
                }
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
