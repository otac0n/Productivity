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
        private static readonly Dictionary<SessionSwitchReason, string> reasonText = new Dictionary<SessionSwitchReason, string>()
        {
            { SessionSwitchReason.SessionLock, "Session Locked" },
            { SessionSwitchReason.SessionUnlock, "Session Unlocked" },
            { SessionSwitchReason.RemoteConnect, "Remote Terminal Connected" },
            { SessionSwitchReason.RemoteDisconnect, "Remote Terminal Disconnected" },
            { SessionSwitchReason.ConsoleConnect, "Remote Console Connected" },
            { SessionSwitchReason.ConsoleDisconnect, "Remote Console Disconnected" },
        };

        private SessionSwitchEventHandler hSessionSwitch;

        public event EventHandler<ActionsEventArgs> EventRaised;

        public SystemStatusEventSource(string settings)
        {
            this.hSessionSwitch = new SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            SystemEvents.SessionSwitch += this.hSessionSwitch;
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            lock (this)
            {
                if (this.EventRaised != null)
                {
                    this.EventRaised(this, new ActionsEventArgs(new AddEventAction(new Event(DateTimeOffset.UtcNow, TimeSpan.Zero, reasonText[e.Reason]))));
                }
            }
        }

        public void Dispose()
        {
            lock (this)
            {
                SystemEvents.SessionSwitch -= this.hSessionSwitch;
            }
        }
    }
}
