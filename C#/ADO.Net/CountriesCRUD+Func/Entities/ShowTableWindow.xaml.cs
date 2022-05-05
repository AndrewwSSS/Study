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

namespace _12._02._2022
{
    public partial class ShowTableWindow : Window
    {
        public ShowTableWindow(IEnumerable<object> items)
        {
            InitializeComponent();
            MainContainer.ItemsSource = items;
        }
    }
}
