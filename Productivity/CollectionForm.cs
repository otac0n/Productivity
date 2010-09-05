using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Productivity
{
    public partial class CollectionForm : Form
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public CollectionForm()
        {
            InitializeComponent();
        }

        private string prev = null;

        private void SetStatus(string status)
        {
            if (status != prev)
            {
                this.textBox1.AppendText(status + "\r\n");
                prev = status;
            }
        }

        private void SnapshotTimer_Tick(object sender, EventArgs e)
        {
            var info = UserContext.GetUserContextInfo();
            if (info != null)
            {
                SetStatus(info.FileName + ":" + info.ProcessId + " (" + info.Title + ") [" + info.HWnd + "]" + (string.IsNullOrEmpty(info.Location) ? string.Empty : "\r\n" + info.Location));
            }
        }
    }
}
