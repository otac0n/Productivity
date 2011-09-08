namespace Productivity
{
    partial class RuleManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button newButton;
            System.Windows.Forms.Button saveButton;
            System.Windows.Forms.Button cancelButton;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label productivityLabel;
            System.Windows.Forms.Label criteriaCodeLabel;
            System.Windows.Forms.ColumnHeader descriptionColumnHeader;
            System.Windows.Forms.ColumnHeader productivityColumnHeader;
            System.Windows.Forms.Button editButton;
            System.Windows.Forms.Button deleteButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleManager));
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.rulesList = new System.Windows.Forms.ListView();
            this.nullProductivity = new System.Windows.Forms.CheckBox();
            this.description = new System.Windows.Forms.TextBox();
            this.productivity = new System.Windows.Forms.NumericUpDown();
            this.codeEditor = new System.Windows.Forms.TextBox();
            newButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            descriptionLabel = new System.Windows.Forms.Label();
            productivityLabel = new System.Windows.Forms.Label();
            criteriaCodeLabel = new System.Windows.Forms.Label();
            descriptionColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            productivityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            editButton = new System.Windows.Forms.Button();
            deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productivity)).BeginInit();
            this.SuspendLayout();
            // 
            // newButton
            // 
            newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            newButton.Location = new System.Drawing.Point(538, 12);
            newButton.Name = "newButton";
            newButton.Size = new System.Drawing.Size(59, 23);
            newButton.TabIndex = 1;
            newButton.Text = "&New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // saveButton
            // 
            saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            saveButton.Location = new System.Drawing.Point(473, 199);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(59, 23);
            saveButton.TabIndex = 7;
            saveButton.Text = "&Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cancelButton.Location = new System.Drawing.Point(538, 199);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(59, 23);
            cancelButton.TabIndex = 8;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(193, 204);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(100, 13);
            descriptionLabel.TabIndex = 5;
            descriptionLabel.Text = "Default &Description:";
            // 
            // productivityLabel
            // 
            productivityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            productivityLabel.AutoSize = true;
            productivityLabel.Location = new System.Drawing.Point(6, 204);
            productivityLabel.Name = "productivityLabel";
            productivityLabel.Size = new System.Drawing.Size(102, 13);
            productivityLabel.TabIndex = 2;
            productivityLabel.Text = "Default &Productivity:";
            // 
            // criteriaCodeLabel
            // 
            criteriaCodeLabel.AutoSize = true;
            criteriaCodeLabel.Location = new System.Drawing.Point(6, 3);
            criteriaCodeLabel.Name = "criteriaCodeLabel";
            criteriaCodeLabel.Size = new System.Drawing.Size(70, 13);
            criteriaCodeLabel.TabIndex = 0;
            criteriaCodeLabel.Text = "Criteria C&ode:";
            // 
            // descriptionColumnHeader
            // 
            descriptionColumnHeader.Text = "Description";
            descriptionColumnHeader.Width = 250;
            // 
            // productivityColumnHeader
            // 
            productivityColumnHeader.Text = "Productivity";
            productivityColumnHeader.Width = 100;
            // 
            // editButton
            // 
            editButton.Location = new System.Drawing.Point(539, 42);
            editButton.Name = "editButton";
            editButton.Size = new System.Drawing.Size(58, 23);
            editButton.TabIndex = 2;
            editButton.Text = "&Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            deleteButton.Location = new System.Drawing.Point(539, 72);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(58, 23);
            deleteButton.TabIndex = 3;
            deleteButton.Text = "&Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(deleteButton);
            this.splitter.Panel1.Controls.Add(editButton);
            this.splitter.Panel1.Controls.Add(newButton);
            this.splitter.Panel1.Controls.Add(this.rulesList);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.nullProductivity);
            this.splitter.Panel2.Controls.Add(saveButton);
            this.splitter.Panel2.Controls.Add(cancelButton);
            this.splitter.Panel2.Controls.Add(this.description);
            this.splitter.Panel2.Controls.Add(descriptionLabel);
            this.splitter.Panel2.Controls.Add(this.productivity);
            this.splitter.Panel2.Controls.Add(productivityLabel);
            this.splitter.Panel2.Controls.Add(criteriaCodeLabel);
            this.splitter.Panel2.Controls.Add(this.codeEditor);
            this.splitter.Panel2.Enabled = false;
            this.splitter.Size = new System.Drawing.Size(609, 394);
            this.splitter.SplitterDistance = 156;
            this.splitter.TabIndex = 0;
            // 
            // rulesList
            // 
            this.rulesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rulesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            descriptionColumnHeader,
            productivityColumnHeader});
            this.rulesList.FullRowSelect = true;
            this.rulesList.HideSelection = false;
            this.rulesList.Location = new System.Drawing.Point(6, 6);
            this.rulesList.Name = "rulesList";
            this.rulesList.Size = new System.Drawing.Size(526, 147);
            this.rulesList.TabIndex = 0;
            this.rulesList.UseCompatibleStateImageBehavior = false;
            this.rulesList.View = System.Windows.Forms.View.Details;
            // 
            // nullProductivity
            // 
            this.nullProductivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nullProductivity.AutoSize = true;
            this.nullProductivity.Checked = true;
            this.nullProductivity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.nullProductivity.Location = new System.Drawing.Point(114, 204);
            this.nullProductivity.Name = "nullProductivity";
            this.nullProductivity.Size = new System.Drawing.Size(15, 14);
            this.nullProductivity.TabIndex = 3;
            this.nullProductivity.UseVisualStyleBackColor = true;
            this.nullProductivity.CheckedChanged += new System.EventHandler(this.nullProductivity_CheckedChanged);
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(299, 201);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(139, 20);
            this.description.TabIndex = 6;
            // 
            // productivity
            // 
            this.productivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.productivity.Location = new System.Drawing.Point(135, 201);
            this.productivity.Name = "productivity";
            this.productivity.Size = new System.Drawing.Size(48, 20);
            this.productivity.TabIndex = 4;
            this.productivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.productivity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // codeEditor
            // 
            this.codeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditor.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEditor.Location = new System.Drawing.Point(6, 19);
            this.codeEditor.Multiline = true;
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(600, 174);
            this.codeEditor.TabIndex = 1;
            // 
            // RuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 394);
            this.Controls.Add(this.splitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuleManager";
            this.Text = "RuleManager";
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.ListView rulesList;
        private System.Windows.Forms.TextBox codeEditor;
        private System.Windows.Forms.NumericUpDown productivity;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.CheckBox nullProductivity;
    }
}