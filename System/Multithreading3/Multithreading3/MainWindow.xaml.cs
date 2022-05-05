using Multithreading3.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Xml.Serialization;

namespace Multithreading3
{

    public partial class MainWindow : Window
    {

        private AutoResetEvent resetEventFindSimpleNumbers = new AutoResetEvent(false);
        private AutoResetEvent resetEventFindSimpleNumbersEndWith7 = new AutoResetEvent(false);
        private AutoResetEvent resetEventGenerateStatistics = new AutoResetEvent(false);


        private ObservableCollection<int> Numbers = new ObservableCollection<int>();
        private ObservableCollection<int> SimpleNumbers =  new ObservableCollection<int>();
        private ObservableCollection<int> SimpleNumbersEndWith7 = new ObservableCollection<int>();
        private ObservableCollection<NumbersFileInfo> FilesInfo = new ObservableCollection<NumbersFileInfo>();


        private Thread GenerateNumbers;
        private Thread FindSimpleNumbersThread;
        private Thread FindSimpleNumbersEndWith7Thread;
        private Thread GenerateStatisticsThread;


        public MainWindow()
        {
            InitializeComponent();

            LB_Numbers.ItemsSource = Numbers;
            LB_SimpleNumbers.ItemsSource= SimpleNumbers;
            LB_SimpleNumbersEndWith7.ItemsSource = SimpleNumbersEndWith7;
            LB_AllInfo.ItemsSource = FilesInfo;

        }



        // 1 thread
        public void FillNumbers()
        {
            Random random = new Random();
            List<int> ListToWrite = new List<int>();

            for (int i = 0; i < random.Next(100, 300); i++)
            {
                int NewNumber = random.Next(10, 500);
                ListToWrite.Add(NewNumber);
                Dispatcher.Invoke(() => { Numbers.Add(NewNumber); });
                Thread.Sleep(100);
            }


            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
  
            using (StreamWriter writer = new StreamWriter(@".\..\..\Files\Numbers.xml"))
            {
                serializer.Serialize(writer, ListToWrite);
            }

            resetEventFindSimpleNumbers.Set();
        }

        // 2 thread
        public void FindSimpleNumbers()
        {
            resetEventFindSimpleNumbers.WaitOne();

            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

            List<int> Numbers;
            List<int> ListToWrite = new List<int>();

            using (StreamReader reader = new StreamReader(@".\..\..\Files\Numbers.xml"))
            {
                Numbers = (List<int>)serializer.Deserialize(reader);
            }

            foreach (int num in Numbers)
            {
                int ModuleNum = Math.Abs(num);
                bool isSimple = true;

                for (int i = 2; i < ModuleNum/2; i++)
                {
                    if (ModuleNum % i == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }

                if (isSimple)
                {
                    Dispatcher.Invoke(() => { SimpleNumbers.Add(num); });
                    ListToWrite.Add(num);
                }
                Thread.Sleep(50);

            }
             
           
            using(StreamWriter writer = new StreamWriter(@".\..\..\Files\SimpleNumbers.xml"))
            {
                serializer.Serialize(writer, ListToWrite);
            }

           
            resetEventFindSimpleNumbersEndWith7.Set();
        }

        // 3 thread
        public void FindSimpleNumbersEndWith7()
        {
            resetEventFindSimpleNumbersEndWith7.WaitOne();

            XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
            List<int> SimpleNumbers = new List<int>();
            List<int> SimpleNumbersEndWith7_ToWrite = new List<int>();

            using (StreamReader reader = new StreamReader(@".\..\..\Files\SimpleNumbers.xml"))
            {
                SimpleNumbers = (List<int>)serializer.Deserialize(reader);
            }

            foreach (var item in SimpleNumbers)
            {
                if (item % 10 == 7)
                {
                    SimpleNumbersEndWith7_ToWrite.Add(item);
                    Dispatcher.Invoke(() => { SimpleNumbersEndWith7.Add(item); });
                }
                Thread.Sleep(150);
            }

            using (StreamWriter writer = new StreamWriter(@".\..\..\Files\SimpleNumbersEndWith7.xml"))
            {
                serializer.Serialize(writer, SimpleNumbersEndWith7_ToWrite);
            }

            resetEventGenerateStatistics.Set();

      

        }

        // 4 thread
        public void GenerateStatistics()
        {
            resetEventGenerateStatistics.WaitOne();

            XmlSerializer serializer = new XmlSerializer(typeof(List<NumbersFileInfo>));
            List<NumbersFileInfo> infos = new List<NumbersFileInfo>();

            foreach (string item in Directory.GetFiles(@".\..\..\Files\").Where(f =>  Path.GetFileName(f) != "Info.xml"))
            {
                NumbersFileInfo fileInfo = new NumbersFileInfo(Path.GetFullPath(item));
                fileInfo.Read();
                infos.Add(fileInfo);
                Dispatcher.Invoke(() => { FilesInfo.Add(fileInfo); });
            }

            using (StreamWriter writer = new StreamWriter(@".\..\..\Files\Info.xml"))
            {
                serializer.Serialize(writer, infos);
            }
        }


        private void BTN_Start_Click(object sender, RoutedEventArgs e)
        {
            GenerateNumbers = new Thread(FillNumbers);
            FindSimpleNumbersThread = new Thread(FindSimpleNumbers);
            FindSimpleNumbersEndWith7Thread = new Thread(FindSimpleNumbersEndWith7);
            GenerateStatisticsThread = new Thread(GenerateStatistics);

            GenerateNumbers.IsBackground = true;
            FindSimpleNumbersThread.IsBackground = true;
            FindSimpleNumbersEndWith7Thread.IsBackground = true;
            GenerateStatisticsThread.IsBackground = true;

            GenerateNumbers.Start();
            FindSimpleNumbersThread.Start();
            FindSimpleNumbersEndWith7Thread.Start();
            GenerateStatisticsThread.Start();

            BTN_Refresh.IsEnabled = true;
            BTN_Start.IsEnabled = false;
        }
        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            try { GenerateNumbers.Abort(); } catch { }
            try { FindSimpleNumbersThread.Abort(); } catch { }
            try { FindSimpleNumbersEndWith7Thread.Abort(); } catch { }
            try { GenerateStatisticsThread.Abort(); } catch { }

            Numbers.Clear();
            SimpleNumbers.Clear();
            SimpleNumbersEndWith7.Clear();
            FilesInfo.Clear();

            BTN_Refresh.IsEnabled = false;
            BTN_Start.IsEnabled = true;
        }
    }
}
