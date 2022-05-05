using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Xml.Serialization;

namespace Multithreading4
{
    public partial class MainWindow : Window
    {
        private AutoResetEvent resetEventCountSumPairs = new AutoResetEvent(false);
        private AutoResetEvent resetEventCountMultiplicationPairs = new AutoResetEvent(false);

        private Thread thread1;
        private Thread thread2;
        private Thread thread3;

        private ObservableCollection<int> Pairs = new ObservableCollection<int>();
        private ObservableCollection<int> SumPairs = new ObservableCollection<int>();
        private ObservableCollection<int> MultiplicationPairs = new ObservableCollection<int>();

        public MainWindow()
        {
            InitializeComponent();
            LB_FirstPairs.ItemsSource = Pairs;
            LB_SecondPairs.ItemsSource = SumPairs;
            LB_ThirdPairs.ItemsSource = MultiplicationPairs;
        }

        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {
            thread1 = new Thread(CreatePairs);
            thread2 = new Thread(CountSumPairs);
            thread3 = new Thread(CountMultiplicationPairs);

            thread1.IsBackground = true;
            thread2.IsBackground = true;
            thread3.IsBackground = true;

            thread1.Start();
            thread2.Start(Pairs);
            thread3.Start(Pairs);

            BTN_Refresh.IsEnabled = true;
            BTN_Start.IsEnabled = false;
        }


        public void CreatePairs()
        {
            List<int> pairs = new List<int>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            Random random = new Random();

            for (int i = 0; i < 2*random.Next(10, 50); i++)
            {
                int number = random.Next(5, 20);

                pairs.Add(number);
                Dispatcher.Invoke(() => { Pairs.Add(number); });

                Thread.Sleep(150);
            }


            using (StreamWriter writer = new StreamWriter(@".\..\..\Files\Pairs.xml"))
            {
                serializer.Serialize(writer, pairs);
            }

            resetEventCountSumPairs.Set();
        }

        public void CountSumPairs(object obj)
        {
            resetEventCountSumPairs.WaitOne();

            if (obj is ObservableCollection<int>)
            {
                ObservableCollection<int> pairs = (ObservableCollection<int>)obj;
                List<int> sumPairs = new List<int>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

                for (int i = 0; i < pairs.Count-1; i += 2)
                {
                    int NewNum = pairs[i] + pairs[i + 1];

                    sumPairs.Add(NewNum);
                    Dispatcher.Invoke(() => { SumPairs.Add(NewNum); });
                    Thread.Sleep(150);
                }

                using (StreamWriter writer = new StreamWriter(@".\..\..\Files\SumPairs.xml"))
                {
                    serializer.Serialize(writer, sumPairs);
                }

            }
            resetEventCountMultiplicationPairs.Set();
        }

        public void CountMultiplicationPairs(object obj)
        {
            resetEventCountMultiplicationPairs.WaitOne();

            if (obj is ObservableCollection<int>)
            {
                ObservableCollection<int> pairs = (ObservableCollection<int>)obj;
                List<int> MultiplicationPairs = new List<int>();
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

                for (int i = 0; i < pairs.Count-1; i += 2)
                {
                    int NewNum = pairs[i] * pairs[i + 1];

                    MultiplicationPairs.Add(NewNum);
                    Dispatcher.Invoke(() => { this.MultiplicationPairs.Add(NewNum); });
                    Thread.Sleep(150);
                }

                using (StreamWriter writer = new StreamWriter(@".\..\..\Files\MultiplicationPairs.xml"))
                {
                    serializer.Serialize(writer, MultiplicationPairs);
                }

            }

        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            thread3.Abort();

            SumPairs.Clear();
            Pairs.Clear();
            MultiplicationPairs.Clear();

            resetEventCountSumPairs.Reset();
            resetEventCountMultiplicationPairs.Reset();

            BTN_Refresh.IsEnabled = false;
            BTN_Start.IsEnabled = true;
        } 
    }
}
