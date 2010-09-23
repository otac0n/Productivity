using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace Productivity.ActiveApplicationAddIn
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
            IntPtr hActive = GetActiveWindow();

            if (hActive == IntPtr.Zero)
            {
                return null;
            }

            uint pId = 0;
            NativeMethods.GetWindowThreadProcessId(hActive, out pId);

            var title = GetWindowTitle(hActive);

            var fileName = GetProcessFilename(pId);
            var fileNameKey = Path.GetFileName(fileName).ToUpperInvariant();

            string location = null;
            LocationSource locationSource = LocationSource.None;

            if (ddeTargets.ContainsKey(fileNameKey))
            {
                try
                {
                    using (var c = new NDde.Client.DdeClient(ddeTargets[fileNameKey], "WWW_GetWindowInfo"))
                    {
                        if (c.TryConnect() == 0)
                        {
                            locationSource = LocationSource.DDE;
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
                catch (NDde.DdeException ex)
                {
                    Debug.Write(ex);
                }
            }
            
            
            if (locationSource == LocationSource.None && pathLookups.ContainsKey(fileNameKey))
            {
                var textHWnd = LookupWindow(hActive, pathLookups[fileNameKey]);

                if (textHWnd != IntPtr.Zero)
                {
                    locationSource = LocationSource.Typed;
                    location = ReadWindowText(textHWnd);
                }
            }

            return new ContextInfo
            {
                HWnd = hActive,
                FileName = fileName,
                Title = title,
                ProcessId = pId,
                Location = location,
                LocationSource = locationSource,
            };
        }

        /// <summary>
        /// Gets the filename of a running process, based on its PID.
        /// </summary>
        private static string GetProcessFilename(uint pId)
        {
            var hProcess = NativeMethods.OpenProcess(NativeMethods.ProcessAccessFlags.QueryInformation, false, pId);

            StringBuilder filePath = new StringBuilder(4096);
            NativeMethods.GetProcessImageFileName(hProcess, filePath, filePath.Capacity);

            NativeMethods.CloseHandle(hProcess);

            return GetDosPath(filePath.ToString());
        }

        /// <summary>
        /// Retrieves the active window's handle.
        /// </summary>
        /// <remarks>
        /// If no window is active, or if the active window is the root desktop window, IntPtr.Zero is returned.
        /// </remarks>
        private static IntPtr GetActiveWindow()
        {
            var hWnd = NativeMethods.GetForegroundWindow();

            if (hWnd != IntPtr.Zero && hWnd != NativeMethods.GetDesktopWindow())
            {
                return hWnd;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Gets the title of a window, from its handle.
        /// </summary>
        /// <remarks>
        /// If the window handle is zero (invalid), or the root desktop window, null is returned.
        /// If the window is the Shell Desktop, the string "Windows Desktop" is returned.
        /// Otherwise, the title of the window (as it is shown to the shell) is returned.
        /// </remarks>
        private static string GetWindowTitle(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero || hWnd == NativeMethods.GetDesktopWindow())
            {
                return null;
            }

            if (hWnd == NativeMethods.GetShellWindow())
            {
                return "Windows Desktop";
            }

            StringBuilder title = new StringBuilder(1024);
            NativeMethods.GetWindowText(hWnd, title, title.Capacity);

            return title.ToString();
        }

        /// <summary>
        /// Reads the text of a window, given its handle.
        /// </summary>
        /// <remarks>
        /// This function works in the case of controls that manage their own text content.
        /// </remarks>
        private static string ReadWindowText(IntPtr hWnd)
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

        /// <summary>
        /// Returns a kernel device path for a DOS drive letter.
        /// </summary>
        private static string GetDrivePath(string driveName)
        {
            driveName = driveName.TrimEnd('\\');

            var ret = new StringBuilder(1024);
            NativeMethods.QueryDosDevice(driveName, ret, ret.Capacity);

            return ret.ToString();
        }

        /// <summary>
        /// Returns a DOS path, given a kernel device path.
        /// </summary>
        /// <remarks>
        /// If the kernel device path cannot be mapped to a drive letter, the kernel device path is returned.
        /// </remarks>
        private static string GetDosPath(string devicePath)
        {
            var drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                var path = GetDrivePath(drive.Name);

                if (devicePath.StartsWith(path, StringComparison.OrdinalIgnoreCase))
                {
                    return drive.Name.TrimEnd('\\') + devicePath.Substring(path.Length);
                }
            }

            return devicePath;
        }

        private static IntPtr LookupWindow(IntPtr parentHWnd, string[][] classNamePath)
        {
            return LookupWindow(parentHWnd, IntPtr.Zero, classNamePath, 0, 0);
        }

        private static IntPtr LookupWindow(IntPtr hWnd, IntPtr afterHWnd, string[][] classNames, int x, int y)
        {
            if (x >= classNames.Length)
            {
                return hWnd;
            }

            var children = classNames[x];

            if (y >= children.Length)
            {
                return LookupWindow(afterHWnd, IntPtr.Zero, classNames, x + 1, 0);
            }

            var className = children[y];

            var hChild = NativeMethods.FindWindowEx(hWnd, afterHWnd, className, null);

            if (hChild == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            return LookupWindow(hWnd, hChild, classNames, x, y + 1);
        }
    }
}
