using System;
using System.Threading;
using System.Windows;
using System.Collections.ObjectModel;

namespace Task3
{
    public partial class MainWindow : Window
    {
        public Thread GenerateFibonacciNumThread;
        public ObservableCollection<long> FibonacciNumbers = new ObservableCollection<long>();

        public MainWindow()
        {
            InitializeComponent();
            LB_FibonacciNumbers.ItemsSource = FibonacciNumbers;
            TB_RightBound.Text = "100";
        }
        private void BTN_StartGenerateFibonacciNumber_Click(object sender, RoutedEventArgs e)
        {
            long Rightbound;

            if (!long.TryParse(TB_RightBound.Text, out Rightbound))
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            GenerateFibonacciNumThread = new Thread(GenerateFibonacciNumbers);
            GenerateFibonacciNumThread.IsBackground = true;
            GenerateFibonacciNumThread.Start(Rightbound);

            BTN_StartGenerateFibonacciNumber.IsEnabled = false;
            BTN_Refresh.IsEnabled = true;
            TB_RightBound.IsEnabled = false;

        }
        public void GenerateFibonacciNumbers(object obj)
        {
            if (obj is long)
            {
                long Rightbound = (long)obj;
                long F1 = 0, F2 = 1, F3;

                while ((F1 + F2) <= Rightbound)
                {
                    F3 = F1 + F2;

                    F1 = F2;
                    F2 = F3;

                    Dispatcher.Invoke(() => { FibonacciNumbers.Add(F3); });
                    Thread.Sleep(200);
                }
            }
        }
        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            try { GenerateFibonacciNumThread.Abort(); } catch { }

            GenerateFibonacciNumThread = null;
            FibonacciNumbers.Clear();

            BTN_StartGenerateFibonacciNumber.IsEnabled = true;
            BTN_Refresh.IsEnabled = false;
            TB_RightBound.IsEnabled = true;
        }
    }
}
