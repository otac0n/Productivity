namespace Productivity
{
    partial class CollectionForm
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

            if (disposing && (this.sources != null))
            {
                foreach (var source in this.sources)
                {
                    source.Dispose();
                }

                this.sources = null;
            }

            if (disposing && (this.processor != null))
            {
                this.processor.Dispose();
                this.processor = null;
            }

            if (disposing && (this.db != null))
            {
                this.db.Dispose();
                this.db = null;
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.NotifyIcon trayIcon;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectionForm));
            System.Windows.Forms.ContextMenuStrip trayMenu;
            System.Windows.Forms.ToolStripMenuItem productivityReviewToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
            trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            productivityReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            trayIcon.Text = "Productivity";
            trayIcon.Visible = true;
            trayIcon.DoubleClick += new System.EventHandler(this.ProductivityReview_Click);
            // 
            // trayMenu
            // 
            trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            productivityReviewToolStripMenuItem,
            exitToolStripMenuItem});
            trayMenu.Name = "trayMenu";
            trayMenu.Size = new System.Drawing.Size(188, 70);
            // 
            // productivityReviewToolStripMenuItem
            // 
            productivityReviewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            productivityReviewToolStripMenuItem.Name = "productivityReviewToolStripMenuItem";
            productivityReviewToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            productivityReviewToolStripMenuItem.Text = "&Productivity Review";
            productivityReviewToolStripMenuItem.Click += new System.EventHandler(this.ProductivityReview_Click);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectionForm";
            this.Text = "Collection";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Shown += new System.EventHandler(this.CollectionForm_Shown);
            trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


    }
}

