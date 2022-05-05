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
    public partial class Task6 : Form
    {
        public Task6() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            LabelDay.Text = DateField.Value.Date.DayOfWeek.ToString();
        }

        private void Task6_Load(object sender, EventArgs e)
        {

        }
    }
}
