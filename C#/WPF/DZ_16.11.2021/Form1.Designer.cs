
namespace DZ_16._11._2021
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarRGB_R = new System.Windows.Forms.TrackBar();
            this.trackBarRGB_G = new System.Windows.Forms.TrackBar();
            this.trackBarRGB_B = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_B)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarRGB_R
            // 
            this.trackBarRGB_R.Location = new System.Drawing.Point(101, 38);
            this.trackBarRGB_R.Maximum = 255;
            this.trackBarRGB_R.Name = "trackBarRGB_R";
            this.trackBarRGB_R.Size = new System.Drawing.Size(290, 45);
            this.trackBarRGB_R.TabIndex = 0;
            this.trackBarRGB_R.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBarRGB_G
            // 
            this.trackBarRGB_G.Location = new System.Drawing.Point(101, 116);
            this.trackBarRGB_G.Maximum = 255;
            this.trackBarRGB_G.Name = "trackBarRGB_G";
            this.trackBarRGB_G.Size = new System.Drawing.Size(290, 45);
            this.trackBarRGB_G.TabIndex = 1;
            this.trackBarRGB_G.Scroll += new System.EventHandler(this.trackBarRGB_G_Scroll);
            // 
            // trackBarRGB_B
            // 
            this.trackBarRGB_B.Location = new System.Drawing.Point(101, 186);
            this.trackBarRGB_B.Maximum = 255;
            this.trackBarRGB_B.Name = "trackBarRGB_B";
            this.trackBarRGB_B.Size = new System.Drawing.Size(290, 45);
            this.trackBarRGB_B.TabIndex = 2;
            this.trackBarRGB_B.Scroll += new System.EventHandler(this.trackBarRGB_B_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(69, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "R";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(69, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "B";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 296);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarRGB_B);
            this.Controls.Add(this.trackBarRGB_G);
            this.Controls.Add(this.trackBarRGB_R);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRGB_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarRGB_R;
        private System.Windows.Forms.TrackBar trackBarRGB_G;
        private System.Windows.Forms.TrackBar trackBarRGB_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

