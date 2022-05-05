using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_12._11._2021
{
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void textBoxDay_TextChanged(object sender, EventArgs e) {
            RenewCalendar();
        }


        private void RenewCalendar()
        {
            if(textBoxDay.Text == "" || textBoxMonth.Text == "" || textBoxYear.Text == "")
                return;
            try {
                monthCalendar.SetDate(new DateTime(Int32.Parse(textBoxYear.Text), Int32.Parse(textBoxMonth.Text), Int32.Parse(textBoxDay.Text)));
            }
            catch (Exception e) {
                MessageBox.Show("Невернный ввод!");
                monthCalendar.SetDate(DateTime.Today);
            }
        }

        private void textBoxMonth_TextChanged(object sender, EventArgs e) {
            RenewCalendar();
        }
        private void textBoxYear_TextChanged(object sender, EventArgs e) {
            RenewCalendar();
        }
    }
}
