using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using  System.Windows.Input;

namespace TextRedactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool isFileOpen = false;
        public string CurrPath;

        TextRange SourcetextRange;
        public bool isTextSave {
            get {
                if (isFileOpen != false)
                    return SourcetextRange.Equals(new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd));
                else 
                    return true;
            }
        } 


        public MainWindow()
        {
            InitializeComponent();
            BTNBoldText.Checked += (obj, e) =>
            {

            };
        }

        private void BTNOpenFile_Click(object sender, RoutedEventArgs e)
        {

            if (isTextSave != true )
            {
                if(MessageBox.Show("Вы не сохранили данные. Сохранить?", "Несохраненные данные", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    Save();
            }


            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    switch (Path.GetExtension(ofd.FileName).ToLower())
                    {
                        case ".rtf":
                            doc.Load(fs, DataFormats.Rtf);
                            CurrPath = ofd.FileName;
                            StatusBar.Text = ofd.FileName;
                            isFileOpen = true;
                            SourcetextRange = new TextRange(doc.Start, doc.End);
                            break;
                        case ".txt":
                            doc.Load(fs, DataFormats.Text);
                            CurrPath = ofd.FileName;
                            StatusBar.Text = ofd.FileName;
                            isFileOpen = true;
                            SourcetextRange = new TextRange(doc.Start, doc.End);
                            break;
                        default:
                            doc.Load(fs, DataFormats.Xaml);
                            CurrPath = ofd.FileName;
                            StatusBar.Text = ofd.FileName;
                            isFileOpen = true;
                            SourcetextRange = new TextRange(doc.Start, doc.End);
                            break;
                       
                    }
                }
            }
        }

        private void BTNSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
            BTNSave.IsChecked = true;
            SourcetextRange = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);

        }

        private void Save()
        {
            TextRange doc = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
            if (isFileOpen)
            {
                using (FileStream fs = File.Create(CurrPath))
                {
                    if (Path.GetExtension(CurrPath).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(CurrPath).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void BTNSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";

            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    switch (Path.GetExtension(sfd.FileName).ToLower())
                    {
                        case ".rtf":
                            doc.Save(fs, DataFormats.Rtf);
                            break;
                        case ".txt":
                            doc.Save(fs, DataFormats.Text);
                            break;
                        default:
                            doc.Save(fs, DataFormats.Xaml);
                            break;

                    }
                }
            }
        }

        private void BTNSetBackColor_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Selection.IsEmpty)
                return;

            System.Windows.Forms.ColorDialog ColDil = new System.Windows.Forms.ColorDialog();
            if (ColDil.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var TextRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
                var TextBrush = new SolidColorBrush(Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B));
                TextRange.ApplyPropertyValue(TextElement.BackgroundProperty, TextBrush);
            }
      

        }
        


        private void BTNSetFgColor_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Selection.IsEmpty)
                return;

            System.Windows.Forms.ColorDialog ColDil = new System.Windows.Forms.ColorDialog();
            if (ColDil.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var TextRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
                var TextBrush = new SolidColorBrush(Color.FromArgb(ColDil.Color.A, ColDil.Color.R, ColDil.Color.G, ColDil.Color.B));
                TextRange.ApplyPropertyValue(TextElement.ForegroundProperty, TextBrush);
            }

        }

        private void BTNBoldText_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Selection.IsEmpty)
                return;

            var TextRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);

            var CurrentFontWeight = TextRange.GetPropertyValue(TextElement.FontWeightProperty);

            if (CurrentFontWeight.Equals(FontWeights.Bold))
            {
                TextRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                BTNBoldText.IsChecked = false;
            }
            else
            {
                TextRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                BTNBoldText.IsChecked = true;

            }

           
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (TextBox.Selection.IsEmpty)
                return;

            var TextRange = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);

            if ((TextRange.GetPropertyValue(TextElement.FontWeightProperty).Equals(FontWeights.Bold))){
                BTNBoldText.IsChecked = true;
                BTNBoldText.Icon = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
           
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {

            if(Keyboard.PrimaryDevice.Modifiers == ModifierKeys.Control)
            {
                TextRange SelectedText = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
                if (SelectedText.IsEmpty)
                {
                    TextRange AllText = new TextRange(TextBox.Document.ContentStart, TextBox.Document.ContentEnd);
                    if (e.Delta < 0)
                    {
                        if ((double)AllText.GetPropertyValue(TextElement.FontSizeProperty) - 2 > 0)
                            AllText.ApplyPropertyValue(TextElement.FontSizeProperty, (double)AllText.GetPropertyValue(TextElement.FontSizeProperty) - 2);
                    }
                        
                    else
                        AllText.ApplyPropertyValue(TextElement.FontSizeProperty, (double)AllText.GetPropertyValue(TextElement.FontSizeProperty) + 2);
                }
                else
                {
                    if (e.Delta < 0)
                    {
                        if((double)SelectedText.GetPropertyValue(TextElement.FontSizeProperty) - 2 > 0)
                            SelectedText.ApplyPropertyValue(TextElement.FontSizeProperty, (double)SelectedText.GetPropertyValue(TextElement.FontSizeProperty) - 2);
                    }
                    else
                        SelectedText.ApplyPropertyValue(TextElement.FontSizeProperty, (double)SelectedText.GetPropertyValue(TextElement.FontSizeProperty) + 2);
                }
               
            }




        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (isTextSave == true)
                BTNSave.IsChecked = true;
            else
                BTNSave.IsChecked = false;
        }




        private void BTNAddLink_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Selection.IsEmpty)
                return;


            var TextRangeg = new TextRange(TextBox.Selection.Start, TextBox.Selection.End);
       
            AddLink addLink = new AddLink(TextBox.Selection);
            addLink.ShowDialog();
        }



    }
}
