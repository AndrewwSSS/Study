
namespace DZ_14._11._2021
{
    partial class Task7
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TimeAsDays = new System.Windows.Forms.RadioButton();
            this.TimeAsMounths = new System.Windows.Forms.RadioButton();
            this.TimeAsMinutes = new System.Windows.Forms.RadioButton();
            this.dateFirst = new System.Windows.Forms.DateTimePicker();
            this.dateSecond = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TimeAsSeconds = new System.Windows.Forms.RadioButton();
            this.TimeAsYears = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // TimeAsDays
            // 
            this.TimeAsDays.AutoSize = true;
            this.TimeAsDays.Location = new System.Drawing.Point(15, 63);
            this.TimeAsDays.Name = "TimeAsDays";
            this.TimeAsDays.Size = new System.Drawing.Size(58, 17);
            this.TimeAsDays.TabIndex = 0;
            this.TimeAsDays.TabStop = true;
            this.TimeAsDays.Text = "В днях";
            this.TimeAsDays.UseVisualStyleBackColor = false;
            this.TimeAsDays.UseWaitCursor = true;
            // 
            // TimeAsMounths
            // 
            this.TimeAsMounths.AutoSize = true;
            this.TimeAsMounths.Location = new System.Drawing.Point(18, 86);
            this.TimeAsMounths.Name = "TimeAsMounths";
            this.TimeAsMounths.Size = new System.Drawing.Size(78, 17);
            this.TimeAsMounths.TabIndex = 1;
            this.TimeAsMounths.TabStop = true;
            this.TimeAsMounths.Text = "В месяцах";
            this.TimeAsMounths.UseVisualStyleBackColor = true;
            // 
            // TimeAsMinutes
            // 
            this.TimeAsMinutes.AutoSize = true;
            this.TimeAsMinutes.Location = new System.Drawing.Point(15, 40);
            this.TimeAsMinutes.Name = "TimeAsMinutes";
            this.TimeAsMinutes.Size = new System.Drawing.Size(76, 17);
            this.TimeAsMinutes.TabIndex = 2;
            this.TimeAsMinutes.TabStop = true;
            this.TimeAsMinutes.Text = "В минутах";
            this.TimeAsMinutes.UseVisualStyleBackColor = true;
            // 
            // dateFirst
            // 
            this.dateFirst.Location = new System.Drawing.Point(176, 24);
            this.dateFirst.Name = "dateFirst";
            this.dateFirst.Size = new System.Drawing.Size(200, 20);
            this.dateFirst.TabIndex = 3;
            // 
            // dateSecond
            // 
            this.dateSecond.Location = new System.Drawing.Point(176, 66);
            this.dateSecond.Name = "dateSecond";
            this.dateSecond.Size = new System.Drawing.Size(200, 20);
            this.dateSecond.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(51, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 31);
            this.label1.TabIndex = 6;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TimeAsSeconds
            // 
            this.TimeAsSeconds.AutoSize = true;
            this.TimeAsSeconds.Location = new System.Drawing.Point(15, 17);
            this.TimeAsSeconds.Name = "TimeAsSeconds";
            this.TimeAsSeconds.Size = new System.Drawing.Size(81, 17);
            this.TimeAsSeconds.TabIndex = 7;
            this.TimeAsSeconds.TabStop = true;
            this.TimeAsSeconds.Text = "В секундах";
            this.TimeAsSeconds.UseVisualStyleBackColor = true;
            // 
            // TimeAsYears
            // 
            this.TimeAsYears.AutoSize = true;
            this.TimeAsYears.Location = new System.Drawing.Point(18, 109);
            this.TimeAsYears.Name = "TimeAsYears";
            this.TimeAsYears.Size = new System.Drawing.Size(63, 17);
            this.TimeAsYears.TabIndex = 8;
            this.TimeAsYears.TabStop = true;
            this.TimeAsYears.Text = "В годах";
            this.TimeAsYears.UseVisualStyleBackColor = true;
            // 
            // Task7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(399, 246);
            this.Controls.Add(this.TimeAsYears);
            this.Controls.Add(this.TimeAsSeconds);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateSecond);
            this.Controls.Add(this.dateFirst);
            this.Controls.Add(this.TimeAsMinutes);
            this.Controls.Add(this.TimeAsMounths);
            this.Controls.Add(this.TimeAsDays);
            this.Name = "Task7";
            this.Text = "Task7";
            this.Load += new System.EventHandler(this.Task7_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton TimeAsDays;
        private System.Windows.Forms.RadioButton TimeAsMounths;
        private System.Windows.Forms.RadioButton TimeAsMinutes;
        private System.Windows.Forms.DateTimePicker dateFirst;
        private System.Windows.Forms.DateTimePicker dateSecond;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TimeAsSeconds;
        private System.Windows.Forms.RadioButton TimeAsYears;
        private System.Windows.Forms.Timer timer1;
    }
}