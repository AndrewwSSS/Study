using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Task1_2.Entities;

namespace Task1_2
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Horse> horses = new ObservableCollection<Horse>();
        public MainWindow()
        {
            InitializeComponent();

            LBProgressControl.ItemsSource = horses;
            TB_CountHorses.Text = "10";
        }
        public Thread RacingThread { get; set; }

        public void StartHorseRacing()
        {
            int NumberOfHorses;

            if (!int.TryParse(TB_CountHorses.Text, out NumberOfHorses))
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Random random = new Random();
            for (int i = 0; i < NumberOfHorses; i++)
            {
                Horse NewHorse = new Horse($"Horse{i + 1}", 100, 1, 6);

                NewHorse.BackgroundColor
                    = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));
                horses.Add(NewHorse);
            }

            RacingThread = new Thread(Racing);

            RacingThread.IsBackground = true;
            TB_CountHorses.IsEnabled = false;
            RacingThread.Start(horses);

            BTN_Refresh.IsEnabled = true;
            BTN_StartHorseRacing.IsEnabled = false;

        }
        public void Racing(object obj)
        {
            if (obj is ObservableCollection<Horse>)
            {
                ObservableCollection<Horse> horses = (ObservableCollection<Horse>)obj;
                Random random = new Random();
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                while (true)
                {
                    for (int i = 0; i < horses.Count; i++)
                        horses[i].NextMove(random, stopwatch);

                    if (horses.Count((h) => h.isFinished) == horses.Count)
                    {
                        stopwatch.Stop();
                        Thread.Sleep(600);
                        Dispatcher.Invoke(OnRacingEnd);
                        return;
                    }
                    Thread.Sleep(600);
                }


            }
        }
        private void BTN_StartHorseRacing_Click(object sender, RoutedEventArgs e)
        {
            StartHorseRacing();
        }
        public void OnRacingEnd()
        {
            List<Horse> Results = horses.ToList().OrderBy(h => h.СheckInTime).ToList();
            StringBuilder ShowResults = new StringBuilder();

            for (int i = 0; i < Results.Count; i++)
                ShowResults.AppendLine($"{i + 1}. {Results[i].Name}. Time: {Results[i].СheckInTime.TotalSeconds}s");

            MessageBox.Show(ShowResults.ToString(), "Results", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            RacingThread.Abort();

            horses.Clear();
            BTN_Refresh.IsEnabled = false;
            BTN_StartHorseRacing.IsEnabled = true;
            TB_CountHorses.IsEnabled = true;
        }
    }
}
