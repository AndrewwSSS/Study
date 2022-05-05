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
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
            label1.Size = new System.Drawing.Size(50, 50);
            label1.BackColor = Color.Sienna;
            label1.AutoSize = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Task5_Load(object sender, EventArgs e)
        {

            label1.Left = (ClientSize.Width - label1.Size.Width) / 2;
            label1.Top = (ClientSize.Height - label1.Size.Height) / 2;
        }

        private void Task5_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.X > label1.Location.X - 20 && e.X < label1.Location.X + label1.Width + 20) &&
                (e.Y > label1.Location.Y - 20 && e.Y < label1.Location.Y + label1.Height + 20))
            {
                if (e.X > label1.Location.X - 20 && e.X < label1.Location.X) //движение курсора с лева по оси Х
                {
                    label1.Left += 10;
                }
                else if (e.X < label1.Location.X + label1.Width + 20 &&
                         e.X > label1.Location.X + label1.Width) //движение курсора с права по оси Х
                {
                    label1.Left -= 10;
                }
                else if (e.Y > label1.Location.Y - 20 && e.Y < label1.Location.Y) //движение курсора с верху по оси У
                {
                    label1.Top += 10;
                }
                else if (e.Y < label1.Location.Y + label1.Height + 20 &&
                         e.Y > label1.Location.Y + label1.Height) //движение курсора с низу по оси У
                {
                    label1.Top -= 10;
                }

                //Проверка границ окна и возврат «статика» в центр
                if ((label1.Location.X < 0 || label1.Location.X > ClientSize.Width - label1.Width) || (label1.Location.Y < 0 || label1.Location.Y > ClientSize.Height - label1.Height))
                    LableCenter(label1);
            }
        }

        // Возвращает кубик в ценрт
        private void LableCenter(Label label1)
        {
            label1.Left = (ClientSize.Width - label1.Size.Width) / 2;
            label1.Top = (ClientSize.Height - label1.Size.Height) / 2;
        }
    }

}