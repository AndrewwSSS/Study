using System.Collections.Generic;
using System.Windows;

namespace DistributionDapper.Entities
{
    public partial class ShowCustomersWindow : Window
    {
        public ShowCustomersWindow(List<Customer> customers)
        {
            InitializeComponent();
            MainDataGrid.ItemsSource = customers;
        }
    }
}
