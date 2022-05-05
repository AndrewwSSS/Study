using Snake.VievwModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Snake
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;

            CBThemes.Items.Add("Gray");
            CBThemes.Items.Add("Blue");
            CBThemes.SelectedItem = "Gray";

            DataContext = new ViewModel(this);
        }

        private void CBTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string style = CBThemes.SelectedItem as string;
            var uri = new Uri(@"/../Model/Themes/" + style + "Theme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
    }
}
