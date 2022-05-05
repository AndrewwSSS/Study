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

namespace BaseConnectToDbWithAdoNet
{
    /// <summary>
    /// Логика взаимодействия для ChoiceDbWindow.xaml
    /// </summary>
    public partial class ChoiceDbWindow : Window
    {
        public string ConnectionString;

        public ChoiceDbWindow(bool canUserCancel = true)
        {
            InitializeComponent();

            if (!canUserCancel)
                BTN_Cancel.IsEnabled = false;
        }

        private void BTN_OK_OnClick(object sender, RoutedEventArgs e)
        {
            ConnectionString = TB_ConnectionString.Text;
            this.Close();
        }

        private void BTN_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
