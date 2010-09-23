namespace Productivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal static class NativeMethods
    {
        public enum HookType : int
        {
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }

        public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public FlashFlags dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        public enum FlashFlags : uint
        {
            FLASHW_STOP = 0,
            FLASHW_CAPTION = 1,
            FLASHW_TRAY = 2,
            FLASHW_ALL = 3,
            FLASHW_TIMER = 4,
            FLASHW_TIMERNOFG = 12
        }

        public static void Flash(this Form form)
        {
            var pwfi = new NativeMethods.FLASHWINFO();
            pwfi.cbSize = (uint)Marshal.SizeOf(pwfi);
            pwfi.hwnd = form.Handle;
            pwfi.dwFlags = NativeMethods.FlashFlags.FLASHW_TIMERNOFG | NativeMethods.FlashFlags.FLASHW_ALL;
            pwfi.uCount = 0;
            pwfi.dwTimeout = 0;

            NativeMethods.FlashWindowEx(ref pwfi);
        }
    }
}
