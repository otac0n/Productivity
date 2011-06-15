using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Productivity.ActiveApplicationAddIn
{
    [DataContract]
    public class ContextInfo
    {
        [DataMember(Name = "fileName", Order = 1)]
        public string FileName
        {
            get;
            set;
        }

        [DataMember(Name = "title", Order = 1)]
        public string Title
        {
            get;
            set;
        }

        [DataMember(Name = "processId", Order = 3)]
        public uint ProcessId
        {
            get;
            set;
        }

        [DataMember(Name = "hWnd", Order = 4)]
        public IntPtr HWnd
        {
            get;
            set;
        }

        [DataMember(Name = "location", Order = 2)]
        public string Location
        {
            get;
            set;
        }

        [IgnoreDataMember]
        public LocationSource LocationSource
        {
            get;
            set;
        }
    }
}
