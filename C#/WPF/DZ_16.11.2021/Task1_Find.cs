using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_16._11._2021
{
    public partial class Task1_Find : Form
    {
        public Task1_Find()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FileDialog openDialog = new OpenFileDialog();
            //openDialog.Filter = $"{textBox1.Text} files (*{textBox1.Text})|*{textBox1.Text}|(*.*)|*.*";

            if(Directory.Exists(label3.Text))
            {
                listBox1.Items.Clear();

                foreach (var file in Directory.GetFiles(label3.Text))
                    if (Path.GetExtension(file) == textBox1.Text)
                        listBox1.Items.Add(Path.GetFileName(file));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openDialog = new FolderBrowserDialog();

            if (openDialog.ShowDialog() == DialogResult.OK)
                label3.Text =  openDialog.SelectedPath;


        }
    }
}
