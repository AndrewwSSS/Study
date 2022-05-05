using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Multithreading1
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<int> Numbers { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<long> FibonacciNumbers { get; set; } = new ObservableCollection<long>();
        public Thread NumbersThread { get; set; }
        public Thread FibonacciThread { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Binding bindingListNumbers = new Binding();
            bindingListNumbers.Source = Numbers;
            LB_Numbers.SetBinding(ItemsControl.ItemsSourceProperty, bindingListNumbers);

            Binding bindingListFibonacci = new Binding();
            bindingListFibonacci.Source = FibonacciNumbers;
            LB_Fibonacci.SetBinding(ItemsControl.ItemsSourceProperty, bindingListFibonacci);
        }

        #region Numbers
        private void StartNumbersThread_Click(object sender, RoutedEventArgs e)
        {
            int leftbound, rightbound;
            Bounds bounds = new Bounds();
            if (!int.TryParse(TBLeftBound.Text, out leftbound))
                bounds.LeftBound = 2;
            else
                bounds.LeftBound = leftbound;
            

            if (!int.TryParse(TBRightBound.Text, out rightbound))
                bounds.isRightBoundSet = false;
            else
            {
                bounds.RightBound = rightbound;
                bounds.isRightBoundSet = true;
            }
                

            if (rightbound < leftbound && bounds.isRightBoundSet == true)
            {
                MessageBox.Show("Invalid input!");
                return;
            }    
                
            NumbersThread = new Thread(StartNumbersThread);
            NumbersThread.IsBackground = true;
            NumbersThread.Start(bounds);

            BTN_PauseNumberThread.IsEnabled = true;
            BTN_StartNumberThread.IsEnabled = false;
            BTN_RefreshNumberThread.IsEnabled = true;
        }

        public void StartNumbersThread(object obj)
        {
            if (obj is Bounds)
            {
                Bounds boundsTmp = (Bounds)obj;

                int CurrentNum = boundsTmp.LeftBound;

                Action action = () => { Numbers.Add(CurrentNum++); };

                if (!boundsTmp.isRightBoundSet)
                {
                    while (true)
                    {
                        Dispatcher.Invoke(action);
                        Thread.Sleep(300);
                    }
                }
                else
                {
                    while (boundsTmp.RightBound+1 != CurrentNum)
                    {
                        Dispatcher.Invoke(action);
                        Thread.Sleep(500);
                    }
                }
            }
        }

        private void BTN_StopNumberThread_Click(object sender, RoutedEventArgs e)
        {
            NumbersThread.Suspend();
            BTN_ResumeNumberThread.IsEnabled = true;
            BTN_PauseNumberThread.IsEnabled = false;
        }

        private void BTN_ResumeNumberThread_Click(object sender, RoutedEventArgs e)
        {
            NumbersThread.Resume();
            BTN_PauseNumberThread.IsEnabled=true;
            BTN_ResumeNumberThread.IsEnabled = false;

        }

        private void BTN_RefreshNumberThread_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                NumbersThread.Suspend();
            }
            catch(Exception ex) { }
           

            NumbersThread = null;


            BTN_PauseNumberThread.IsEnabled = false;
            BTN_RefreshNumberThread.IsEnabled = false;
            BTN_ResumeNumberThread.IsEnabled = false;
            BTN_StartNumberThread.IsEnabled = true;
            Numbers.Clear();
        }

        #endregion Numbers

        #region Fibonacci
        private void StartFibonacciThread_Click(object sender, RoutedEventArgs e)
        {
            if(FibonacciThread == null)
            {
                FibonacciThread = new Thread(StartFibonacciThread);
                FibonacciThread.IsBackground = true;

                FibonacciThread.Start();

                BTN_StartFibonacciThread.IsEnabled = false;
                BTN_PauseFibonacciThread.IsEnabled=true;
                BTN_RefreshFibonacciThread.IsEnabled = true;    
            }
         
        }

        public void StartFibonacciThread(object obj)
        {
            long Fb1 = 0;
            long Fb2 = 1;
            long Fb3 = 0;


            Action a = () =>
            {
                FibonacciNumbers.Add(Fb3);
            };

           

            while (true)
            {
                Fb3 = Fb1 + Fb2;

                Dispatcher.Invoke(a);

                Fb1 = Fb2;
                Fb2 = Fb3;
                Thread.Sleep(300);
            }

        }


        private void BTN_PauseFibonacciThread_Click(object sender, RoutedEventArgs e)
        {
            FibonacciThread.Suspend();
            BTN_ResumeFibonacciThread.IsEnabled = true;
            BTN_PauseFibonacciThread.IsEnabled = false;

        }


        #endregion Fibonacci

        private void BTN_ResumeFibonacciThread_Click(object sender, RoutedEventArgs e)
        {
            FibonacciThread.Resume();
            BTN_PauseFibonacciThread.IsEnabled = true;
            BTN_ResumeFibonacciThread.IsEnabled =false;
        }

        private void BTN_RefreshFibonacciThread_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                FibonacciThread.Suspend();
            }
            catch (Exception ex) { }
           
            FibonacciThread = null;

            BTN_PauseFibonacciThread.IsEnabled = false;
            BTN_StartFibonacciThread.IsEnabled = true;
            BTN_ResumeFibonacciThread.IsEnabled = false;
            BTN_RefreshFibonacciThread.IsEnabled = false;

            FibonacciNumbers.Clear();
        }
    }
}
