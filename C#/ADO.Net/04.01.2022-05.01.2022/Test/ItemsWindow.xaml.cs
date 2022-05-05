using System.Data;
using System.Windows;

namespace Test
{

    public partial class ItemsWindow : Window
    {
        public ItemsWindow(DataTable items)
        {
            InitializeComponent();
            MainDataGrid.ItemsSource = items.DefaultView;
        }
    }
}
