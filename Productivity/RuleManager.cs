using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Productivity.Analysis;
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

        private void newButton_Click(object sender, EventArgs e)
        {
            OpenEditor();
        }

        private void OpenEditor(Rule rule = null)
        {
            if (rule != null)
            {
                this.codeEditor.Text = rule.Expression;
                this.productivity.Value = rule.Productivity;
                this.description.Text = rule.Description;
            }

            this.splitter.Panel1.Enabled = false;
            this.splitter.Panel2.Enabled = true;
        }

        private void CloseEditor()
        {
            this.codeEditor.Text = "";
            this.productivity.Value = 50;
            this.description.Text = "";
            this.splitter.Panel2.Enabled = false;
            this.splitter.Panel1.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var code = this.codeEditor.Text;

            var compiler = new ScriptCompiler();
            try
            {
                var func = ScriptManager.GetScriptFunc(code);
            }
            catch (ScriptCompileFailedException ex)
            {
                var errors = from err in ex.Errors
                             where Path.GetFileName(err.FileName) == "script"
                             select string.Format("({0},{1}) {2}: {3}", err.Line, err.Column, err.ErrorNumber, err.ErrorText, err.FileName);

                if (!errors.Any())
                {
                    errors = from err in ex.Errors
                             select string.Format("{2}: {3}", err.Line, err.Column, err.ErrorNumber, err.ErrorText, err.FileName);
                }

                MessageBox.Show(string.Join(Environment.NewLine, errors));
            }

            // TODO: Save the rule.
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO: Confirm the cancellation.
            CloseEditor();
        }
    }
}
