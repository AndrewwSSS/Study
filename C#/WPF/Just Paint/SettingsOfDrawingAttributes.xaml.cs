using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _11._12._2021
{
    /// <summary>
    /// Логика взаимодействия для SettingsOfDrawingAttributes.xaml
    /// </summary>
    /// 



    public partial class SettingsOfDrawingAttributes : Window
    {
        public DrawingAttributes attributes { get; set; }

        public SettingsOfDrawingAttributes(DrawingAttributes attributes)
        {
            InitializeComponent();
            this.attributes = attributes;

            attributes.IsHighlighter = true;
            ColorOfFether.Fill = new SolidColorBrush(Color.FromRgb(attributes.Color.R, attributes.Color.G, attributes.Color.B));

            for (int i = 2; i < 50; i += 2)
            {
                FeatherWidth.Items.Add(i);
            }
            FeatherWidth.SelectedItem = (int)attributes.Width;

           


        }

        private void BTNSelectColor_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.ColorDialog ColDil = new System.Windows.Forms.ColorDialog();


            if (ColDil.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorOfFether.Fill = new SolidColorBrush(Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B));
                attributes.Color = Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B);
            }
        }
        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            attributes.Width = (int)FeatherWidth.SelectedItem;
            attributes.Height = (int)FeatherWidth.SelectedItem;
            DialogResult = true;
            this.Close();
        }

    }

}