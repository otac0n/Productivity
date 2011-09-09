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
            this.analysisWorker = new System.ComponentModel.BackgroundWorker();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.timeScoredLabel = new System.Windows.Forms.Label();
            this.productivityBar = new Productivity.ProductivityBar();
            toolStrip = new System.Windows.Forms.ToolStrip();
            refreshButton = new System.Windows.Forms.ToolStripButton();
            manageRulesButton = new System.Windows.Forms.ToolStripButton();
            toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            toolStrip.SuspendLayout();
            toolStripContainer.ContentPanel.SuspendLayout();
            toolStripContainer.TopToolStripPanel.SuspendLayout();
            toolStripContainer.SuspendLayout();
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
            toolStripContainer.ContentPanel.Controls.Add(this.timeScoredLabel);
            toolStripContainer.ContentPanel.Controls.Add(this.scoreLabel);
            toolStripContainer.ContentPanel.Controls.Add(this.productivityBar);
            toolStripContainer.ContentPanel.Size = new System.Drawing.Size(572, 237);
            toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            toolStripContainer.Location = new System.Drawing.Point(0, 0);
            toolStripContainer.Name = "toolStripContainer";
            toolStripContainer.Size = new System.Drawing.Size(572, 262);
            toolStripContainer.TabIndex = 0;
            toolStripContainer.Text = "toolStripContainer";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            toolStripContainer.TopToolStripPanel.Controls.Add(toolStrip);
            // 
            // analysisWorker
            // 
            this.analysisWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.analysisWorker_DoWork);
            this.analysisWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.analysisWorker_RunWorkerCompleted);
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
            // timeScoredLabel
            // 
            this.timeScoredLabel.AutoSize = true;
            this.timeScoredLabel.Location = new System.Drawing.Point(15, 88);
            this.timeScoredLabel.Name = "timeScoredLabel";
            this.timeScoredLabel.Size = new System.Drawing.Size(32, 13);
            this.timeScoredLabel.TabIndex = 2;
            this.timeScoredLabel.Text = "0 min";
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
            // ProductivityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 262);
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
            this.ResumeLayout(false);

        }

        #endregion

        private ProductivityBar productivityBar;
        private System.ComponentModel.BackgroundWorker analysisWorker;
        private System.Windows.Forms.Label timeScoredLabel;
        private System.Windows.Forms.Label scoreLabel;

    }
}