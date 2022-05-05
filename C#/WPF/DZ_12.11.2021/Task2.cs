using System;
using System.Windows.Forms;

namespace DZ_12._11._2021
{
    public partial class Task2 : Form
    {
        public Task2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            TimeSpan fSpan = dateSecond.Value.Date.Subtract(dateFirst.Value.Date);
            label1.Text ="Результат: " + fSpan.TotalDays.ToString();
        }
    }
}
