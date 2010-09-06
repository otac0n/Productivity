using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventsLibrary;
using System.Diagnostics;
using System.Security.Permissions;

namespace Productivity.StandardPlugins
{
    public sealed class MouseActivitySource : IEventSource
    {
        private readonly TimeSpan idleTimeSpan;
        private Event previousEvent;

        private IntPtr hMouseHook;
        private NativeMethods.HookProc MouseProc;

        public event EventHandler<ActionsEventArgs> EventRaised;

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public MouseActivitySource(string settings)
        {
            int seconds = 0;
            seconds = int.TryParse(settings, out seconds) ? seconds : 20;
            this.idleTimeSpan = TimeSpan.FromSeconds(seconds);

            this.MouseProc = new NativeMethods.HookProc(MouseCallback);

            using (Process process = Process.GetCurrentProcess())
            using (ProcessModule module = process.MainModule)
            {
                var hModule = NativeMethods.GetModuleHandle(module.ModuleName);

                hMouseHook = NativeMethods.SetWindowsHookEx(NativeMethods.HookType.WH_MOUSE_LL, MouseProc, hModule, 0);
            }
        }

        ~MouseActivitySource()
        {
        }

        private IntPtr MouseCallback(int code, IntPtr wParam, IntPtr lParam)
        {
            var actions = this.GetActions();

            if (this.EventRaised != null)
            {
                this.EventRaised(this, new ActionsEventArgs(actions));
            }

            return NativeMethods.CallNextHookEx(this.hMouseHook, code, wParam, lParam);
        }

        private IList<EventAction> GetActions()
        {
            var now = DateTimeOffset.UtcNow;
            Event newEvent;

            if (this.previousEvent == null || this.previousEvent.Time + this.previousEvent.Duration + this.idleTimeSpan < now)
            {
                this.previousEvent = null;
                newEvent = new Event(now, TimeSpan.Zero, "Mouse Active", this.GetType());
            }
            else
            {
                newEvent = new Event(this.previousEvent.Time, now - this.previousEvent.Time, "Mouse Active", this.GetType());
            }

            var actions = new List<EventAction>();
            actions.Add(new AddEventAction(newEvent));

            if (this.previousEvent != null)
            {
                actions.Add(new RemoveEventAction(this.previousEvent));
            }

            this.previousEvent = newEvent;

            return actions;
        }

        public void Dispose()
        {
            NativeMethods.UnhookWindowsHookEx(this.hMouseHook);
            this.hMouseHook = IntPtr.Zero;
        }
    }
}
