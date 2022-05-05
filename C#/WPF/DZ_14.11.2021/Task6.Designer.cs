
namespace DZ_14._11._2021
{
    partial class Task6
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
            this.DateField = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LabelDay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DateField
            // 
            this.DateField.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateField.Location = new System.Drawing.Point(95, 9);
            this.DateField.Name = "DateField";
            this.DateField.Size = new System.Drawing.Size(79, 20);
            this.DateField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Укажите дату";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Показать день недели";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LabelDay
            // 
            this.LabelDay.AutoSize = true;
            this.LabelDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDay.Location = new System.Drawing.Point(22, 92);
            this.LabelDay.Name = "LabelDay";
            this.LabelDay.Size = new System.Drawing.Size(0, 25);
            this.LabelDay.TabIndex = 3;
            // 
            // Task6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 148);
            this.Controls.Add(this.LabelDay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateField);
            this.Name = "Task6";
            this.Text = "Task6";
            this.Load += new System.EventHandler(this.Task6_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LabelDay;
    }
}