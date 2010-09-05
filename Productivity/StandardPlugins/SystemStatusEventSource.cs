using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using Microsoft.Win32;

namespace Productivity.StandardPlugins
{
    public sealed class SystemStatusEventSource : IEventSource
    {
        private SessionSwitchEventHandler hSessionSwitch;

        public SystemStatusEventSource(string settings)
        {
            this.hSessionSwitch = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += this.hSessionSwitch;
        }

        private void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                SetStatus("[Workstation Locked]");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                SetStatus("[Workstation Unlocked]");
            }
        }
    }
}
