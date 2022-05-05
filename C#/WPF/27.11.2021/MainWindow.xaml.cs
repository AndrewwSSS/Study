using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace _27._11._2021
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Brush TmpBrush;
        public bool isPressed = false;
        public Button TmpButton;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

          
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            TmpButton.Background = TmpBrush;
            isPressed = false;
        }

        private void Grid_KeyDown_1(object sender, KeyEventArgs e)
        {
            MessageBox.Show("hi");
        }

        private void OnButtonPress(Button button)
        {
            if (isPressed == false)
            {
                TmpBrush = button.Background;
                TmpButton = button;
                button.Background = new SolidColorBrush(Colors.White);
                isPressed = true;
            }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var child in GridMain.Children)
            {
                if (child is Grid)
                {
                    foreach (var children in (child as Grid).Children)
                    {
                        if (children is Button)
                        {

                            if (((children as Button).Content.ToString() as string) == e.Key.ToString()
                                || (e.Key.ToString() == "Back" && (children as Button).Content.ToString() == "Back Space")
                                || (e.Key.ToString() == "OemPeriod" && (children as Button).Content.ToString() == ">")
                                || (e.Key.ToString() == "LeftShift" && (children as Button).Content.ToString() == "L Shift")
                                || (e.Key.ToString() == "RightShift" && (children as Button).Content.ToString() == "R Shift")
                                || (e.Key.ToString() == "Capital" && (children as Button).Content.ToString() == "Caps Lock")
                                || (e.Key.ToString() == "OemComma" && (children as Button).Content.ToString() == "<")
                                || (e.Key.ToString() == "Return" && (children as Button).Content.ToString() == "Enter")
                                || e.Key.ToString() == "Up" 
                                || e.Key.ToString() == "Down"
                               )
                            {
                               

                                switch (e.Key.ToString())
                                {
                                    case "Back":
                                        if (InputText.Text.Length != 0)
                                            InputText.Text = InputText.Text.Remove(InputText.Text.Length - 1);
                                        OnButtonPress(children as Button);
                                        break;
                                    case "Space": 
                                        InputText.Text += " ";
                                        OnButtonPress(children as Button);
                                        break;
                                    case "OemPeriod":
                                        InputText.Text += ".";
                                        OnButtonPress(children as Button);
                                        break;
                                    case "OemComma":
                                        InputText.Text += ",";
                                        OnButtonPress(children as Button);
                                        break;
                                    case "Up":
                                        InputText.FontSize += 2;
                                        break;
                                    case "Down":
                                        if (InputText.FontSize - 2 >= 1)
                                            InputText.FontSize -= 2;
                                        break;
                                    case "Tab":
                                        InputText.Text += "    ";
                                        OnButtonPress(children as Button);
                                        break;
                                    case "Capital":
                                        // TODO
                                        OnButtonPress(children as Button);
                                        break;
                                    case "LeftShift":
                                        // TODO
                                        OnButtonPress(children as Button);
                                        break;
                                    case "RightShift":
                                        // TODO
                                        OnButtonPress(children as Button);
                                        break;
                                    case "Return":
                                        InputText.Text = "";
                                        OnButtonPress(children as Button);
                                        break;
                                    default:
                                        if(e.KeyboardDevice.Modifiers == ModifierKeys.Shift) InputText.Text += e.Key.ToString();
                                        else InputText.Text += e.Key.ToString().ToLower();

                                        OnButtonPress(children as Button);
                                        break;
                                }
                                return;
                            }

                        }
                    }
                }
                

            }



        }


    }
}
