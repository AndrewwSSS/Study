
namespace DZ_14._11._2021
{
    partial class Task1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAverage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CountOfLabel = new System.Windows.Forms.Label();
            this.LabelOurLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(200, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Федоров Андрій";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(200, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Стаж роботи: 0 років";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(177, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Язики программування: C++, C#";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelAverage
            // 
            this.labelAverage.AutoSize = true;
            this.labelAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAverage.Location = new System.Drawing.Point(134, 279);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(334, 20);
            this.labelAverage.TabIndex = 3;
            this.labelAverage.Text = "Среднее число символов на странице";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(191, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Резюме";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CountOfLabel
            // 
            this.CountOfLabel.AutoSize = true;
            this.CountOfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountOfLabel.Location = new System.Drawing.Point(134, 248);
            this.CountOfLabel.Name = "CountOfLabel";
            this.CountOfLabel.Size = new System.Drawing.Size(153, 20);
            this.CountOfLabel.TabIndex = 5;
            this.CountOfLabel.Text = "Количество label";
            // 
            // LabelOurLength
            // 
            this.LabelOurLength.AutoSize = true;
            this.LabelOurLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelOurLength.Location = new System.Drawing.Point(134, 210);
            this.LabelOurLength.Name = "LabelOurLength";
            this.LabelOurLength.Size = new System.Drawing.Size(306, 20);
            this.LabelOurLength.TabIndex = 6;
            this.LabelOurLength.Text = "Количество символов на странице";
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 360);
            this.Controls.Add(this.LabelOurLength);
            this.Controls.Add(this.CountOfLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAverage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Task1";
            this.Text = "Task1";
            this.Load += new System.EventHandler(this.Task1_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Task1_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAverage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CountOfLabel;
        private System.Windows.Forms.Label LabelOurLength;
    }
}