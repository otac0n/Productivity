namespace Productivity
{
    partial class ProductivityView
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
            System.Windows.Forms.ToolStrip toolStrip;
            System.Windows.Forms.ToolStripButton refreshButton;
            System.Windows.Forms.ToolStripButton manageRulesButton;
            System.Windows.Forms.ToolStripContainer toolStripContainer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductivityView));
            this.timeScoredLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.analysisWorker = new System.ComponentModel.BackgroundWorker();
            this.tabView = new System.Windows.Forms.TabControl();
            this.unclassifiedEventsTab = new System.Windows.Forms.TabPage();
            this.unclassifiedEventsList = new System.Windows.Forms.ListView();
            this.productivityBar = new Productivity.ProductivityBar();
            this.startTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            toolStrip = new System.Windows.Forms.ToolStrip();
            refreshButton = new System.Windows.Forms.ToolStripButton();
            manageRulesButton = new System.Windows.Forms.ToolStripButton();
            toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            toolStrip.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
            this.tabView.SuspendLayout();
            this.unclassifiedEventsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            refreshButton,
            manageRulesButton});
            toolStrip.Location = new System.Drawing.Point(3, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new System.Drawing.Size(58, 25);
            toolStrip.TabIndex = 0;
            // 
            // refreshButton
            // 
            refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            refreshButton.Image = global::Productivity.Properties.Resources.Refresh;
            refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new System.Drawing.Size(23, 22);
            refreshButton.Text = "Refresh";
            refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // manageRulesButton
            // 
            manageRulesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            manageRulesButton.Image = global::Productivity.Properties.Resources.Settings;
            manageRulesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            manageRulesButton.Name = "manageRulesButton";
            manageRulesButton.Size = new System.Drawing.Size(23, 22);
            manageRulesButton.Text = "Manage Rules";
            manageRulesButton.Click += new System.EventHandler(this.manageRulesButton_Click);
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            toolStripContainer.ContentPanel.Controls.Add(this.tabView);
            toolStripContainer.ContentPanel.Controls.Add(this.timeScoredLabel);
            toolStripContainer.ContentPanel.Controls.Add(this.scoreLabel);
            toolStripContainer.ContentPanel.Controls.Add(this.productivityBar);
            toolStripContainer.ContentPanel.Size = new System.Drawing.Size(572, 333);
            toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            toolStripContainer.Location = new System.Drawing.Point(0, 0);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new System.Drawing.Size(572, 358);
            toolStripContainer.TabIndex = 0;
            toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // timeScoredLabel
            // 
            this.timeScoredLabel.AutoSize = true;
            this.timeScoredLabel.Location = new System.Drawing.Point(15, 88);
            this.timeScoredLabel.Name = "timeScoredLabel";
            this.timeScoredLabel.Size = new System.Drawing.Size(32, 13);
            this.timeScoredLabel.TabIndex = 2;
            this.timeScoredLabel.Text = "0 min";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(12, 16);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(98, 31);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "0.00 %";
            // 
            // analysisWorker
            // 
            this.analysisWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.analysisWorker_DoWork);
            this.analysisWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.analysisWorker_RunWorkerCompleted);
            // 
            // tabView
            // 
            this.tabView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabView.Controls.Add(this.unclassifiedEventsTab);
            this.tabView.Location = new System.Drawing.Point(13, 120);
            this.tabView.Name = "tabView";
            this.tabView.SelectedIndex = 0;
            this.tabView.Size = new System.Drawing.Size(547, 201);
            this.tabView.TabIndex = 3;
            // 
            // unclassifiedEventsTab
            // 
            this.unclassifiedEventsTab.Controls.Add(this.unclassifiedEventsList);
            this.unclassifiedEventsTab.Location = new System.Drawing.Point(4, 22);
            this.unclassifiedEventsTab.Name = "unclassifiedEventsTab";
            this.unclassifiedEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.unclassifiedEventsTab.Size = new System.Drawing.Size(539, 175);
            this.unclassifiedEventsTab.TabIndex = 0;
            this.unclassifiedEventsTab.Text = "Unclassified";
            this.unclassifiedEventsTab.UseVisualStyleBackColor = true;
            // 
            // unclassifiedEventsList
            // 
            this.unclassifiedEventsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.startTimeColumn,
            this.endTimeColumn,
            this.dataColumn});
            this.unclassifiedEventsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unclassifiedEventsList.Location = new System.Drawing.Point(3, 3);
            this.unclassifiedEventsList.Name = "unclassifiedEventsList";
            this.unclassifiedEventsList.Size = new System.Drawing.Size(533, 169);
            this.unclassifiedEventsList.TabIndex = 0;
            this.unclassifiedEventsList.UseCompatibleStateImageBehavior = false;
            this.unclassifiedEventsList.View = System.Windows.Forms.View.Details;
            // 
            // productivityBar
            // 
            this.productivityBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productivityBar.Location = new System.Drawing.Point(12, 50);
            this.productivityBar.Name = "productivityBar";
            this.productivityBar.Segments = null;
            this.productivityBar.Size = new System.Drawing.Size(548, 35);
            this.productivityBar.StartTime = new System.DateTime(2011, 9, 7, 5, 0, 0, 0);
            this.productivityBar.TabIndex = 0;
            this.productivityBar.TimeSpan = System.TimeSpan.Parse("1.00:00:00");
            // 
            // startTimeColumn
            // 
            this.startTimeColumn.Text = "Start Time";
            // 
            // endTimeColumn
            // 
            this.endTimeColumn.Text = "End Time";
            // 
            // dataColumn
            // 
            this.dataColumn.Text = "Data";
            // 
            // ProductivityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 358);
            this.Controls.Add(toolStripContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductivityView";
            this.Text = "ProductivityView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProductivityView_FormClosing);
            this.Shown += new System.EventHandler(this.ProductivityView_Shown);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            toolStripContainer.ContentPanel.ResumeLayout(false);
            toolStripContainer.ContentPanel.PerformLayout();
            toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer.TopToolStripPanel.PerformLayout();
            toolStripContainer.ResumeLayout(false);
            toolStripContainer.PerformLayout();
            this.tabView.ResumeLayout(false);
            this.unclassifiedEventsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ProductivityBar productivityBar;
        private System.ComponentModel.BackgroundWorker analysisWorker;
        private System.Windows.Forms.Label timeScoredLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.TabControl tabView;
        private System.Windows.Forms.TabPage unclassifiedEventsTab;
        private System.Windows.Forms.ListView unclassifiedEventsList;
        private System.Windows.Forms.ColumnHeader startTimeColumn;
        private System.Windows.Forms.ColumnHeader endTimeColumn;
        private System.Windows.Forms.ColumnHeader dataColumn;

    }
}