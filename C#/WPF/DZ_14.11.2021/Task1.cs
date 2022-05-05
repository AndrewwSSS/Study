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
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Task1_Load(object sender, EventArgs e)
        {
            List<object> labels = new List<object>();


            foreach (var control in this.Controls) 
                if (control.GetType().Name == "Label") 
                    labels.Add(control);
            
            int countOfSymbol = 0;

            foreach (var label in labels) 
                countOfSymbol += (label as Label).Text.Length;

            CountOfLabel.Text   = "Количество label: " + labels.Count.ToString();
            LabelOurLength.Text = "Количество символов в labels: " + countOfSymbol.ToString();
            labelAverage.Text   = "Cреднее число символов на странице: " + ((float)countOfSymbol / (float)labels.Count).ToString();

        }

        private void Task1_MouseDoubleClick(object sender, MouseEventArgs e) {

            List<object> labels = new List<object>();

            foreach (var control in this.Controls)
                if (control.GetType().Name == "Label")
                    labels.Add(control);

            int countOfSymbol = 0;
            foreach (var label in labels)
                countOfSymbol += (label as Label).Text.Length;
            LabelOurLength.Text = "Количество символов в labels: " + countOfSymbol.ToString();
            CountOfLabel.Text = "Количество label: " + labels.Count.ToString();
            labelAverage.Text = "Cреднее число символов на странице: " + ((float)countOfSymbol / (float)labels.Count).ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

    }
}
