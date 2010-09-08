using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace Productivity.StandardPlugins
{
    public static class UserContext
    {
        private static Dictionary<string, string> ddeTargets = new Dictionary<string, string>()
        {
            { "IEXPLORE.EXE", "IExplore" },
            { "FIREFOX.EXE", "Firefox" },
            { "OPERA.EXE", "Opera" },

            { "NETSCAPE.EXE", "Netscape" },
            { "MOSAIC.EXE", "Mosaic" },
        };

        private static Dictionary<string, string[][]> pathLookups = new Dictionary<string, string[][]>()
        {
            { "CHROME.EXE", new [] { new [] { "Chrome_AutocompleteEditView" } } },
            { "SAFARI.EXE", new [] { new [] { "RootElement" }, new [] { "SafariEdit" }, new [] { "WebKitEdit" }  } },
        };

        public static ContextInfo GetUserContextInfo()
        {
            IntPtr hActive = NativeMethods.GetForegroundWindow();
            if (hActive == IntPtr.Zero)
            {
                return null;
            }

            uint pId = 0;
            NativeMethods.GetWindowThreadProcessId(hActive, out pId);

            StringBuilder title = new StringBuilder(1024);
            NativeMethods.GetWindowText(hActive, title, title.Capacity);

            var hProcess = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.QueryInformation, false, pId);
            StringBuilder filePath = new StringBuilder(4096);
            NativeMethods.GetProcessImageFileName(hProcess, filePath, filePath.Capacity);
            var fileName = Path.GetFileName(filePath.ToString()).ToUpperInvariant();
            var fileNameKey = fileName.ToUpperInvariant();

            string location = null;
            LocationSource locationSource = LocationSource.None;

            if (ddeTargets.ContainsKey(fileNameKey))
            {
                locationSource = LocationSource.DDE;
                try
                {
                    using (var c = new NDde.Client.DdeClient(ddeTargets[fileNameKey], "WWW_GetWindowInfo"))
                    {
                        if (c.TryConnect() == 0)
                        {
                            var res = c.Request("0xFFFFFFFF", int.MaxValue);
                            if (res != null)
                            {
                                res = res.TrimEnd('\0');
                                var parts = res.Split(',');
                                location = parts[0].Trim('\"');
                            }
                        }
                    }
                }
                catch (NDde.DdeException)
                {
                }
            }
            else if (pathLookups.ContainsKey(fileNameKey) && string.IsNullOrEmpty(location))
            {
                locationSource = LocationSource.Typed;
                location = LookupText(hActive, IntPtr.Zero, pathLookups[fileNameKey], 0, 0);
            }

            return new ContextInfo
            {
                HWnd = hActive,
                FileName = fileName,
                Title = title.ToString(),
                ProcessId = pId,
                Location = location,
                LocationSource = locationSource,
            };
        }

        private static string LookupText(IntPtr hWnd, IntPtr afterHWnd, string[][] classNames, int x, int y)
        {
            if (x >= classNames.Length)
            {
                var length = NativeMethods.SendMessage(hWnd, NativeMethods.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero).ToInt32();

                if (length == 0)
                {
                    return string.Empty;
                }

                StringBuilder text = new StringBuilder(length + 1);
                NativeMethods.SendMessage(hWnd, NativeMethods.WM_GETTEXT, new IntPtr(text.Capacity), text);

                return text.ToString();
            }

            var children = classNames[x];

            if (y >= children.Length)
            {
                return LookupText(afterHWnd, IntPtr.Zero, classNames, x + 1, 0);
            }

            var className = children[y];

            var hChild = NativeMethods.FindWindowEx(hWnd, afterHWnd, className, null);

            if (hChild == IntPtr.Zero)
            {
                return null;
            }

            return LookupText(hWnd, hChild, classNames, x, y + 1);
        }
    }
}
