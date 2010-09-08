using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using Microsoft.Win32;

namespace Productivity.StandardPlugins
{
    public sealed class ActiveApplicationSource : IEventSource
    {
        public event EventHandler<ActionsEventArgs> EventRaised;

        public ActiveApplicationSource()
        {
        }

        private string prev = null;

        private void SnapshotTimer_Tick(object sender, EventArgs e)
        {
            var info = UserContext.GetUserContextInfo();
            if (info != null)
            {
                //SetStatus(info.FileName + ":" + info.ProcessId + " (" + info.Title + ") [" + info.HWnd + "]" + (string.IsNullOrEmpty(info.Location) ? string.Empty : "\r\n" + info.Location));
            }
        }

        public void Dispose()
        {
        }
    }
}
