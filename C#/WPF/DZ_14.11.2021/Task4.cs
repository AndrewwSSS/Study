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
    public partial class Task4 : Form
    {
        private List<Label> rectangles = new List<Label>();

        private Point p1Point;

        public Task4()
        {
            InitializeComponent();
        }

        private void Task4_Load(object sender, EventArgs e)
        {

        }

        private void Task4_MouseDown(object sender, MouseEventArgs e)
        {
            p1Point = e.Location;
        }

        private void Task4_MouseUp(object sender, MouseEventArgs e)
        {

            Rectangle nRectangle = new Rectangle(p1Point, e.Location);
            if (nRectangle.height > 10 && nRectangle.width > 10) {
                Label newLabel = new Label();
                newLabel.BackColor = Color.Blue;
                newLabel.Location = nRectangle.P1;
                newLabel.Size = new Size(nRectangle.width, nRectangle.height);
                newLabel.Visible = true;
                newLabel.AutoSize = false;

                newLabel.MouseDoubleClick += new MouseEventHandler(this.label_DoubleClick);
                newLabel.MouseClick += new  MouseEventHandler(this.label_Click);


                this.Controls.Add(newLabel);
                this.rectangles.Add(newLabel);
            }
            else MessageBox.Show("Площадь прямоугольника не может быть меньше чем 10х10!", "Недопустимое действие", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void label_DoubleClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                Controls.Remove((sender as Label));
                rectangles.Remove((sender as Label));
            }
        }

        private void label_Click(object sender, MouseEventArgs e)
        {
            this.Text = "Площадь: " + (sender as Label).Height + "x" + (sender as Label).Width
                + ", " + Cursor.Position.X + " " + Cursor.Position.Y;
            this.Invalidate();

        }

        private void Task4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = Cursor.Position.X + " " + Cursor.Position.Y;
        }
    }

    class  Rectangle
    {
        public Point P1;
        public Point P2;

        public int height {
            get => Math.Abs(P1.Y - P2.Y);
        }

        public int width {
            get => Math.Abs(P1.X - P2.X);
        }


        public Rectangle(Point p1, Point p2)
        {

           // MessageBox.Show(p1.X + " " + p1.Y + " | " + p2.X + " " + p2.Y);


            if (p1.X > p2.X && p1.Y > p2.Y) 
            {
                P1 = p2;
                P2 = p1;
            }
            // Если нужно в левый нижный угол
            else if (p1.X > p2.X && p1.Y < p2.Y)
            {
                this.P1 = new Point(p2.X, p1.Y);
                this.P2 = new Point(p1.X, p2.Y);
            }
            // Если нужно в левый верхний угол
            else if (p1.X < p2.X && p1.Y > p2.Y)
            {
                this.P1 = new Point(p1.X, p2.Y);
                this.P2 = new Point(p2.X, p1.Y);
            }
            else
            {
                P2 = p2;
                P1 = p1;
            }



        }

    }

}
