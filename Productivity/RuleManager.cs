using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Productivity.Models;

namespace Productivity
{
    public partial class RuleManager : Form
    {
        private EventsConnection db;

        public RuleManager(EventsConnection db)
        {
            InitializeComponent();

            this.db = db;
        }
    }
}
