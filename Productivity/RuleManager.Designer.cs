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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleManager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rulesList = new System.Windows.Forms.ListView();
            this.description = new System.Windows.Forms.TextBox();
            this.productivity = new System.Windows.Forms.NumericUpDown();
            this.codeEditor = new System.Windows.Forms.TextBox();
            newButton = new System.Windows.Forms.Button();
            saveButton = new System.Windows.Forms.Button();
            cancelButton = new System.Windows.Forms.Button();
            descriptionLabel = new System.Windows.Forms.Label();
            productivityLabel = new System.Windows.Forms.Label();
            criteriaCodeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(newButton);
            this.splitContainer1.Panel1.Controls.Add(this.rulesList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(saveButton);
            this.splitContainer1.Panel2.Controls.Add(cancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.description);
            this.splitContainer1.Panel2.Controls.Add(descriptionLabel);
            this.splitContainer1.Panel2.Controls.Add(this.productivity);
            this.splitContainer1.Panel2.Controls.Add(productivityLabel);
            this.splitContainer1.Panel2.Controls.Add(criteriaCodeLabel);
            this.splitContainer1.Panel2.Controls.Add(this.codeEditor);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(609, 394);
            this.splitContainer1.SplitterDistance = 156;
            this.splitContainer1.TabIndex = 0;
            // 
            // rulesList
            // 
            this.rulesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rulesList.Location = new System.Drawing.Point(6, 6);
            this.rulesList.Name = "rulesList";
            this.rulesList.Size = new System.Drawing.Size(526, 147);
            this.rulesList.TabIndex = 0;
            this.rulesList.UseCompatibleStateImageBehavior = false;
            this.rulesList.View = System.Windows.Forms.View.Details;
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
            // 
            // cancelButton
            // 
            cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            cancelButton.Location = new System.Drawing.Point(538, 199);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(59, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Location = new System.Drawing.Point(299, 201);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(139, 20);
            this.description.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(193, 204);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(100, 13);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Default &Description:";
            // 
            // productivity
            // 
            this.productivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.productivity.Location = new System.Drawing.Point(114, 201);
            this.productivity.Name = "productivity";
            this.productivity.Size = new System.Drawing.Size(48, 20);
            this.productivity.TabIndex = 3;
            this.productivity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.productivity.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
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
            criteriaCodeLabel.TabIndex = 1;
            criteriaCodeLabel.Text = "Criteria C&ode:";
            // 
            // codeEditor
            // 
            this.codeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeEditor.Location = new System.Drawing.Point(6, 19);
            this.codeEditor.Multiline = true;
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(600, 174);
            this.codeEditor.TabIndex = 0;
            // 
            // RuleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 394);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RuleManager";
            this.Text = "RuleManager";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productivity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView rulesList;
        private System.Windows.Forms.TextBox codeEditor;
        private System.Windows.Forms.NumericUpDown productivity;
        private System.Windows.Forms.TextBox description;
    }
}