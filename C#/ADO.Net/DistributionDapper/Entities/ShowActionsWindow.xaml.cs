using System.Collections.Generic;
using System.Windows;

namespace DistributionDapper.Entities
{
    /// <summary>
    /// Логика взаимодействия для ShowActionsWindow.xaml
    /// </summary>
    public partial class ShowActionsWindow : Window
    {
        public ShowActionsWindow(List<PromotionalProduct> items)
        {
            InitializeComponent();
            MainDataGrid.ItemsSource = items;
        }
    }
}
