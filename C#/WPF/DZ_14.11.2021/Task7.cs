using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_14._11._2021
{
    public partial class Task7 : Form
    {
        private List<object> radioButtons = new List<object>();

        public Task7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Task7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           TimeSpan fSpan = dateFirst.Value.Date.Subtract(dateSecond.Value.Date);

           if (TimeAsDays.Checked) label1.Text = "Результат: " + Math.Abs(fSpan.TotalDays).ToString();
           else if (TimeAsMinutes.Checked) label1.Text = "Результат: " + Math.Abs(fSpan.Minutes).ToString();
           else if (TimeAsMounths.Checked) label1.Text = "Результат: " + Math.Abs(fSpan.Days / 31.0).ToString();
           else if (TimeAsYears.Checked) label1.Text = "Результат: " + Math.Abs((double)fSpan.Days / 365).ToString();
           else if (TimeAsSeconds.Checked) label1.Text = "Результат: " + Math.Abs(fSpan.TotalSeconds).ToString();
        }
    }
}
