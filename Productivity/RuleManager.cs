﻿using System;
using System.Data.Common;
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
            ReloadRulesList();
        }

        private void ReloadRulesList()
        {
            this.rulesList.Items.Clear();
            foreach (var rule in this.db.Rules)
            {
                var item = new ListViewItem(new[] { rule.Description, rule.Productivity.ToString() });
                item.Tag = rule;
                this.rulesList.Items.Add(item);
            }
        }

        private void OpenEditor(Rule rule = null)
        {
            if (rule != null)
            {
                this.codeEditor.Text = rule.Expression;
                this.productivity.Value = rule.Productivity;
                this.description.Text = rule.Description;
                this.splitter.Panel2.Tag = rule;
            }

            this.splitter.Panel1.Enabled = false;
            this.splitter.Panel2.Enabled = true;
        }

        private void CloseEditor()
        {
            this.codeEditor.Text = "";
            this.productivity.Value = 50;
            this.description.Text = "";
            this.splitter.Panel2.Tag = null;
            this.splitter.Panel2.Enabled = false;
            this.splitter.Panel1.Enabled = true;
        }

        private void UpdateRule(Rule rule)
        {
            rule.Expression = this.codeEditor.Text;
            rule.Productivity = (int)this.productivity.Value;
            rule.Description = this.description.Text;
        }

        private Rule GetSelectedRule()
        {
            if (this.rulesList.SelectedItems.Count != 1)
            {
                return null;
            }

            return this.rulesList.SelectedItems[0].Tag as Rule;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            OpenEditor();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var rule = GetSelectedRule();
            if (rule != null)
            {
                OpenEditor(rule);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var compiler = new ScriptCompiler();
                var func = ScriptManager.GetScriptFunc(this.codeEditor.Text);
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
                return;
            }

            var rule = (Rule)this.splitter.Panel2.Tag;
            if (rule == null)
            {
                rule = new Rule();
                this.db.Rules.AddObject(rule);
            }

            UpdateRule(rule);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbException ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            CloseEditor();
            ReloadRulesList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // TODO: Confirm the cancellation.
            CloseEditor();
        }
    }
}
