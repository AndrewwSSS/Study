using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Xml.Serialization;

namespace Task1_3
{

    public partial class MainWindow : Window
    {
        Thread MainThread;
        CancellationTokenSource cts = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();
        }


        public void StartAnalysis(object obj)
        {
            if (obj is string)
            {
                TextAnalytics Analytics = new TextAnalytics((string)obj);

                //Simulation hard working
                Thread.Sleep(5000);
                Analytics.StartAnalysis();

                Dispatcher.Invoke(() => { OnAnalysisEnded(Analytics); });

            }
        }

        public void OnAnalysisEnded(TextAnalytics Analytics)
        {

            if (MessageBox.Show("Save results in file ?", "", MessageBoxButton.YesNo) == MessageBoxResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TextAnalytics));

                try
                {
                    using (StreamWriter writer = new StreamWriter(@".\save.xml"))
                    {
                        serializer.Serialize(writer, Analytics);
                    }
                }
                catch (Exception) { }

            }

            StringBuilder stringBuilder = new StringBuilder();

            if (CB_NumberOfWords.IsChecked == true)
                stringBuilder.AppendLine($"Number of words: {Analytics.NumberOfWords}");


            if (CB_NumberOfSymbols.IsChecked == true)
                stringBuilder.AppendLine($"Number of symbols: {Analytics.NumberOfSymbols}");


            if (CB_NumberOfSentences.IsChecked == true)
                stringBuilder.AppendLine($"Number of sentences: {Analytics.NumberOfSentences}");


            if (CB_NumberOfExclamatorySentences.IsChecked == true)
                stringBuilder.AppendLine($"Number of exclamatory sentences: {Analytics.NumberOfExclamatorySentences}");


            if (CB_NumberOfInterrogativeSentences.IsChecked == true)
                stringBuilder.AppendLine($"Number of interrogative sentences: {Analytics.NumberOfInterrogativeSentences}");


            MessageBox.Show(stringBuilder.ToString(), "Results", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BTN_StartAnalisis_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TB_StringToAnalysis.Text))
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MainThread = new Thread(StartAnalysis);
            MainThread.IsBackground = true;

            MainThread.Start(TB_StringToAnalysis.Text);

            BTN_StartAnalisis.IsEnabled = false;
            BTN_StopAnalisis.IsEnabled = true;
        }

        private void BTN_StopAnalisis_Click(object sender, RoutedEventArgs e)
        {
            try { MainThread.Abort(); } catch { }

            BTN_StartAnalisis.IsEnabled = true;
            BTN_StopAnalisis.IsEnabled = false;
        }
    }
}
