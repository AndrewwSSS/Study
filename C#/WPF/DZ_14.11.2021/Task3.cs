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
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void Task3_Load(object sender, EventArgs e)
        {

        }

        private void Task3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(Control.ModifierKeys == Keys.Control)
                this.Close();

            int clientWidth = ClientSize.Width;
            int clientHeight = ClientSize.Height;

            if (e.X < clientWidth - 10 && e.X > 10 && e.Y > 10 && e.Y < clientHeight - 10)
            {
                MessageBox.Show($"Точка относительно прямоугольника: {e.X - 10} {e.Y - 10}\nТочка снаружи: {e.X} {e.Y}",
                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Task3_ResizeEnd(object sender, EventArgs e) {
            this.Text = ClientSize.Width + " " + ClientSize.Height;
        }

        private void Task3_MouseMove(object sender, MouseEventArgs e) {
            this.Text = e.X + " " + e.Y;
        }
    }
}
