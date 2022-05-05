
namespace DZ_14._11._2021
{
    partial class Task3
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 887);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1929, 1080);
            this.MinimumSize = new System.Drawing.Size(940, 678);
            this.Name = "Task3";
            this.Text = "Task3";
            this.Load += new System.EventHandler(this.Task3_Load);
            this.ResizeEnd += new System.EventHandler(this.Task3_ResizeEnd);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Task3_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Task3_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
    }
}