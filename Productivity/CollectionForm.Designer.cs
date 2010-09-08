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
            this.SuspendLayout();
            // 
            // CollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "CollectionForm";
            this.Text = "Collection";
            this.ResumeLayout(false);

        }

        #endregion

    }
}

