using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextRedactor
{
    /// <summary>
    /// Логика взаимодействия для AddLink.xaml
    /// </summary>
    public partial class AddLink : Window
    {

        public TextSelection Sec;

        public AddLink(TextSelection section)
        {
            Sec = section;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (String.IsNullOrEmpty(TBLink.Text) != true && String.IsNullOrWhiteSpace(TBLink.Text) != true)
            {
                Hyperlink hyperlink = new Hyperlink(Sec.Start, Sec.End);
                hyperlink.NavigateUri = new System.Uri(TBLink.Text);
                hyperlink.MouseDown += LinkClicked;

                var TextRange = new TextRange(Sec.Start, Sec.End);
                TextRange.ApplyPropertyValue(FontStyleProperty, FontStyles.Italic);
                DialogResult = true;
                
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }


        private void LinkClicked(object sender, MouseButtonEventArgs e) {
            try
            {
                System.Diagnostics.Process.Start((sender as Hyperlink).NavigateUri.ToString());
            }
            catch(Exception ex)
            {

            }
        
        }
    }
}
