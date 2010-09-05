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
            this.SnapshotTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ScreenshotTimer = new System.Windows.Forms.Timer(this.components);
            this.QueueProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SnapshotTimer
            // 
            this.SnapshotTimer.Enabled = true;
            this.SnapshotTimer.Tick += new System.EventHandler(this.SnapshotTimer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(292, 266);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // ScreenshotTimer
            // 
            this.ScreenshotTimer.Enabled = true;
            this.ScreenshotTimer.Interval = 10000;
            // 
            // QueueProcessTimer
            // 
            this.QueueProcessTimer.Enabled = true;
            this.QueueProcessTimer.Tick += new System.EventHandler(this.QueueProcessTimer_Tick);
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.textBox1);
            this.Name = "CollectionForm";
            this.Text = "Collection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer SnapshotTimer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer ScreenshotTimer;
        private System.Windows.Forms.Timer QueueProcessTimer;
    }
}

