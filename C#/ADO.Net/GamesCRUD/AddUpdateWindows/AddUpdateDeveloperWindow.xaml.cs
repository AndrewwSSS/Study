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

namespace _18._02._2022.AddUpdateWindows
{
    /// <summary>
    /// Логика взаимодействия для AddUpdateDeveloperWindow.xaml
    /// </summary>
    public partial class AddUpdateDeveloperWindow : Window
    {
        public Developer Result { get; set; }

        public AddUpdateDeveloperWindow()
        {
            InitializeComponent();
        }

        public AddUpdateDeveloperWindow(Developer developer)
        {
            InitializeComponent();

            TB_Name.Text = developer.Name;
            // Тут косяки с неймингом, из-за ModelFirst
            LB_Games.ItemsSource = developer.Game;
        }

        private void BTN_Save_OnClick(object sender, RoutedEventArgs e)
        {
            if (TB_Name.Text == "")
            {
                MessageBox.Show("Error");
                return;
            }

            Result = new Developer()
            {
                Name = TB_Name.Text
            };

            DialogResult = true;
            this.Close();
        }

        private void BTN_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
