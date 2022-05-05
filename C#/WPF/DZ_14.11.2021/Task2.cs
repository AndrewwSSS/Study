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
    public partial class Task2 : Form
    {
        private int Num;
        private int numberOfAttempts = 0;


        public Task2()
        {
            InitializeComponent();
            Num = new Random().Next(1, 200);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int res;
            if (Int32.TryParse(textBoxInput.Text, out res)) {
                if (Num == res) {
                    MessageBox.Show($"Вы угадли число. Число попыток: {numberOfAttempts}");
                    numberOfAttempts = 0;
                    Num = new Random().Next(1, 200);
                }
                else {
                    MessageBox.Show("К сожалению вы не угадли число");
                    numberOfAttempts++;
                }
            }
            else MessageBox.Show("Вы ввели лишний символ или знак", "Некоректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBoxInput.Clear();
            labelCount.Text = numberOfAttempts.ToString();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }
    }
}
