using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace _11._12._2021
{
    public partial class MainWindow : Window
    {
        public string NameOFShape { get; set; }

        public Point point1 { get; set; }

        public Shape shapeTmp { get; set; }

        public bool isDrawing = false;
        public bool isFirstDraw = true;


        public SolidColorBrush SelectedColor { get; set; }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            SelectedColor = new SolidColorBrush(Color.FromRgb(0, 0, 255));

        }

        private void Field_MouseDown(object sender, MouseButtonEventArgs e) {
            point1 = e.GetPosition(Field as IInputElement);
            if (NameOFShape != "Paint")
                isDrawing = true;

        }

        private void Field_MouseUp(object sender, MouseButtonEventArgs e)        {
            isDrawing = false;
            isFirstDraw = true;
        }

        private void BTNLine_Click(object sender, RoutedEventArgs e) {
            Field.EditingMode = InkCanvasEditingMode.None;
            NameOFShape = "Line";
        }

        private void BTNRectange_Click(object sender, RoutedEventArgs e) {
            Field.EditingMode = InkCanvasEditingMode.None;
            NameOFShape = "Rectangle";
        }

        private void BTNOval_Click(object sender, RoutedEventArgs e)
        {
            Field.EditingMode = InkCanvasEditingMode.None;
            NameOFShape = "Ellipse";
        }

        private void BTNPaint_Click(object sender, RoutedEventArgs e)
        {
            NameOFShape = "Paint";
            Field.EditingMode = InkCanvasEditingMode.Ink;
        }




        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point point2 = e.GetPosition(Field as IInputElement);
                if (isFirstDraw)
                {
                    switch (NameOFShape)
                    {

                        case "Rectangle":
                            {
                                RectangleINFO INFO = new RectangleINFO(point1, point2);
                                Rectangle NewRectangle = new Rectangle();

                                InkCanvas.SetLeft(NewRectangle, INFO.P1.X);
                                InkCanvas.SetTop(NewRectangle, INFO.P1.Y);

                                NewRectangle.Width = INFO.width;
                                NewRectangle.Height = INFO.height;

                                NewRectangle.Fill = new SolidColorBrush() { Color = SelectedColor.Color };
                                Field.Children.Add(NewRectangle);
                                shapeTmp = NewRectangle;
                                isFirstDraw = false;
                                break;
                            }
                        case "Line":
                            Line NewLine = new Line();
                            NewLine.X1 = point1.X;
                            NewLine.Y1 = point1.Y;

                            NewLine.X2 = point2.X;
                            NewLine.Y2 = point2.Y;

                            NewLine.StrokeThickness = 5;
                            NewLine.Stroke = new SolidColorBrush() { Color = SelectedColor.Color };

                            Field.Children.Add(NewLine);
                            shapeTmp = NewLine;
                            isFirstDraw = false;
                            break;

                        case "Ellipse":
                            {
                                RectangleINFO INFO = new RectangleINFO(point1, point2);
                                Ellipse NewElipse = new Ellipse();

                                InkCanvas.SetLeft(NewElipse, INFO.P1.X);
                                InkCanvas.SetTop(NewElipse, INFO.P1.Y);

                                NewElipse.Width = INFO.width;
                                NewElipse.Height = INFO.height;

                                NewElipse.Fill = new SolidColorBrush() { Color = SelectedColor.Color };
                                Field.Children.Add(NewElipse);
                                shapeTmp = NewElipse;
                                isFirstDraw = false;
                                break;
                            }
                    }
                }
                else
                {
                    switch (NameOFShape)
                    {
                        case "Line":
                            (shapeTmp as Line).X2 = point2.X;
                            (shapeTmp as Line).Y2 = point2.Y;
                            break;
                        default:
                            RectangleINFO INFO = new RectangleINFO(point1, point2);
                            InkCanvas.SetLeft(shapeTmp, INFO.P1.X);
                            InkCanvas.SetTop(shapeTmp, INFO.P1.Y);

                            shapeTmp.Width = INFO.width;
                            shapeTmp.Height = INFO.height;
                            break;
                    }
                }
            }
        }

        private void BTNSelectColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog ColDil = new System.Windows.Forms.ColorDialog();


            if(ColDil.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedColor = new SolidColorBrush(Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B));
                Field.DefaultDrawingAttributes.Color = Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B);
            }
               
        }

        private void BTNSelectBackColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog ColDil = new System.Windows.Forms.ColorDialog();


            if (ColDil.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Field.Background = new SolidColorBrush(Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B));
        }

        private void BTNClear_Click(object sender, RoutedEventArgs e)
        {
            Field.Children.Clear();
            Field.Strokes.Clear();
            
        }

        private void BTNSetings_Click(object sender, RoutedEventArgs e)
        {
            SettingsOfDrawingAttributes settings = new SettingsOfDrawingAttributes(Field.DefaultDrawingAttributes);

            if(settings.ShowDialog() == true)
            {

            }


        }
    }

    public class RectangleINFO
    {
        public Point P1;
        public Point P2;

        public double height
        {
            get => Math.Abs(P1.Y - P2.Y);
        }

        public double width
        {
            get => Math.Abs(P1.X - P2.X);
        }


        public RectangleINFO(Point p1, Point p2)
        {
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
