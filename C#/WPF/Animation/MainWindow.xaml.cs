using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace AnimationDZ
{
    public partial class MainWindow : Window
    {
        Queue<string> uris = new Queue<string>();
        ThicknessAnimation Animation = new ThicknessAnimation();

        public MainWindow()
        {
          
            InitializeComponent();
            Animation.Completed += Animation_Completed;
            Animation.From = Slide.Margin;
            Animation.To =  new Thickness(Slide.Margin.Left - 300, Slide.Margin.Top - 300, Slide.Margin.Right - 300, Slide.Margin.Bottom-300);
            Animation.Duration = TimeSpan.FromSeconds(10);
          
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            if(uris.Count != 0)
            {
                Slide.Source = new BitmapImage(new Uri(uris.Dequeue()));
                Slide.BeginAnimation(Image.MarginProperty, Animation);
            }
        }

        private void BTNOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
          
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                uris.Clear();
                foreach (string file in Directory.GetFiles(dialog.SelectedPath))
                {
                    string fileEx = System.IO.Path.GetExtension(file);
                    if (fileEx == ".jpg" || fileEx == ".png")
                        uris.Enqueue(file);
                }
                Slide.Source = new BitmapImage(new Uri(uris.Dequeue()));
                Slide.BeginAnimation(Image.MarginProperty, Animation);
            }
                
              


        }
    }
}
