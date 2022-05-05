using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Task4_5
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {
            if(Directory.Exists(TB_PathToDirecrory.Text) && Directory.Exists(TB_PathToHub.Text) && !Directory.Equals(TB_PathToDirecrory.Text, TB_PathToHub.Text))
            {

                List<string> Arguments = new List<string> { TB_PathToDirecrory.Text, TB_PathToHub.Text };
                Task MainTask = Task.Factory.StartNew(StartWork, Arguments);
                BTN_Start.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Invalid arguments", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        public void StartWork(object obj)
        {
            if (obj is List<string> && ((List<string>)obj).Count == 2)
            {
                List<string> Arguments = (List<string>)obj;
                FindAndSelectUniqueFiles findAndSelectUnique = new FindAndSelectUniqueFiles(Arguments[0], Arguments[1]);
                findAndSelectUnique.StartAnalysis();

                Dispatcher.Invoke(() => { OnMainTaskEnded(findAndSelectUnique); });
                return;
            }
            Dispatcher.Invoke(() => { BTN_Start.IsEnabled = true; });
        }

        public void OnMainTaskEnded(FindAndSelectUniqueFiles obj)
        {
            BTN_Start.IsEnabled = true;
            MessageBox.Show(obj.GenerateStatistics(), "Report", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
