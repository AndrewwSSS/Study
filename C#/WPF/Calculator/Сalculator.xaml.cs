using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace _26._11._2021
{
    /// <summary>
    /// Логика взаимодействия для Сalculator.xaml
    /// </summary>
    public partial class Сalculator : Window
    {

        public Сalculator() {
            Directory.GetFiles("fff", "", SearchOption.AllDirectories);
            InitializeComponent();
            this.Height = SystemParameters.FullPrimaryScreenHeight * 0.7;
 
            this.Width = SystemParameters.FullPrimaryScreenWidth * 0.25;
        }

        private void Button_CE_Click(object sender, RoutedEventArgs e) {
            TextBlock_Main.Text = "";
        }

        private void Button_C_Click(object sender, RoutedEventArgs e) {
            TextBlock_Main.Text = "";
            TextBlock_Last.Text = "";
        }

        private void Button_LT_Click(object sender, RoutedEventArgs e) {
            if(TextBlock_Main.Text.Length != 0)
                TextBlock_Main.Text = TextBlock_Main.Text.Remove(TextBlock_Main.Text.Length - 1);
        }


        private void SimpleButton_Click(object sender, RoutedEventArgs e) {
            TextBlock_Main.Text += (string)((Button)sender).Content;
        }


        private void Button_Count(object sender, RoutedEventArgs e)
        {
            try {
                TextBlock_Last.Text = TextBlock_Main.Text;
                TextBlock_Main.Text = Convert.ToDouble(new DataTable().Compute(TextBlock_Main.Text, null)).ToString();
                TextBlock_Last.Text += $" = {TextBlock_Main.Text}";
            }
            catch(Exception) { }

        }
    
    }
}
