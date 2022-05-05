
namespace DZ_12._11._2021
{
    partial class Task2
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
            this.dateFirst = new System.Windows.Forms.DateTimePicker();
            this.dateSecond = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateFirst
            // 
            this.dateFirst.Location = new System.Drawing.Point(58, 26);
            this.dateFirst.Name = "dateFirst";
            this.dateFirst.Size = new System.Drawing.Size(200, 20);
            this.dateFirst.TabIndex = 0;
            // 
            // dateSecond
            // 
            this.dateSecond.Location = new System.Drawing.Point(58, 78);
            this.dateSecond.Name = "dateSecond";
            this.dateSecond.Size = new System.Drawing.Size(200, 20);
            this.dateSecond.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(28, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 305);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateSecond);
            this.Controls.Add(this.dateFirst);
            this.Name = "Task2";
            this.Text = "Task2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateFirst;
        private System.Windows.Forms.DateTimePicker dateSecond;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}