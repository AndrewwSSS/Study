using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using FileInfo = Task4_5.Entities.FileInfo;
using System.Windows.Controls;

namespace Task4_5
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<FileInfo> FilesInfos = new ObservableCollection<FileInfo>();
        private Thread CountByFolderThread { get; set; }
        private Thread CountByFileThread { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
            binding.Source = FilesInfos;
            LB_Main.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            //LB_Main.ItemsSource = FilesInfos;
        }
        private void BTN_CountOccurrencesByPathToFile_Click(object sender, RoutedEventArgs e)
        {
            string wordToFind;
            if (string.IsNullOrWhiteSpace(TB_WorldToFind.Text))
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                wordToFind = TB_WorldToFind.Text;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "txt files (*.txt)|*.txt";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CountByFolderThread = new Thread(CountOccurrencesByPathToFile);
                    FileInfo fileInfo = new FileInfo(dialog.FileName, wordToFind);
                    CountByFolderThread.Start(fileInfo);
                }
            }
        }
        private void BTN_CountOccurrencesByPathToFolder_Click(object sender, RoutedEventArgs e)
        {
            string wordToFind;
            List<string> Files;
 
            if (string.IsNullOrWhiteSpace(TB_WorldToFind.Text))
            {
                MessageBox.Show("Invalid input!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
                wordToFind = TB_WorldToFind.Text;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Files = (Directory.GetFiles(fbd.SelectedPath, "*.txt", SearchOption.AllDirectories).ToList());
                List<FileInfo> filesInfo = new List<FileInfo>();
                CountByFileThread = new Thread(CountOccurrencesByPathToFolder);

                for (int i = 0; i < Files.Count; i++) 
                    filesInfo.Add(new FileInfo(Files[i], wordToFind));

                CountByFileThread.IsBackground = true;
                CountByFileThread.Start(filesInfo);
            }
        }
        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            FilesInfos.Clear();
        }

        public void CountOccurrencesByPathToFolder(object obj)
        {
            if (obj is List<FileInfo>)
            {
                List<FileInfo> files = (List<FileInfo>)obj;

                foreach (FileInfo file in files)
                    file.StartFinding();
                

                Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < files.Count; i++)
                        FilesInfos.Add(files[i]);
                });
            }
        }
        public void CountOccurrencesByPathToFile(object obj)
        {
            if(obj is FileInfo)
            {
                FileInfo fileInfo = (FileInfo)obj;

                fileInfo.StartFinding();

                Dispatcher.Invoke(() =>
                {
                    FilesInfos.Add(fileInfo);
                });
            }
        }

    }
}
