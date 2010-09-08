using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Productivity.StandardPlugins
{
    public class ContextInfo
    {
        public string FileName
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public uint ProcessId
        {
            get;
            set;
        }

        public IntPtr HWnd
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public LocationSource LocationSource
        {
            get;
            set;
        }
    }
}
