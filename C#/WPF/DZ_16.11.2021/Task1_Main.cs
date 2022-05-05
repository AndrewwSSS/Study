using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_16._11._2021
{
    public partial class Task1_Main : Form
    {
         //private List<Form> forms;
         public Task1_Main()
         {
            InitializeComponent();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            Task1_Find newTaskFind = new Task1_Find();
            newTaskFind.Show();



        }
    }
}
