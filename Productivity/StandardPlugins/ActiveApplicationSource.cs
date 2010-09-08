using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using Microsoft.Win32;
using System.Threading;

namespace Productivity.StandardPlugins
{
    public sealed class ActiveApplicationSource : IEventSource
    {
        private Timer timer;

        public event EventHandler<ActionsEventArgs> EventRaised;

        public ActiveApplicationSource()
        {
            this.timer = new Timer(SnapshotTimer_Tick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void SnapshotTimer_Tick(object state)
        {
            var info = UserContext.GetUserContextInfo();
            if (info != null)
            {
                //SetStatus(info.FileName + ":" + info.ProcessId + " (" + info.Title + ") [" + info.HWnd + "]" + (string.IsNullOrEmpty(info.Location) ? string.Empty : "\r\n" + info.Location));
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
