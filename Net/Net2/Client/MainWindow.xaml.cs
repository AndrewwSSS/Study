using ClassesLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;

namespace Client
{
    public partial class MainWindow : Window
    {
        Socket socket;
        IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Parse("26.246.72.11"), 1488);
        byte[] buffer = new byte[8192];

        public MainWindow()
        {
            InitializeComponent();
        }


        public void ConnectCallBack(IAsyncResult ai)
        {
            try
            {
                socket.EndConnect(ai);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => { BTN_Find.IsEnabled = true; TB_Index.IsEnabled = true; });
            }
         
            int PostIndex = (int)ai.AsyncState;
            byte[] ToSend;
            ToSend = BitConverter.GetBytes(PostIndex);
            socket.BeginSend(ToSend, 0, ToSend.Length, 0, SendCallBack, null);
        }

        public void SendCallBack(IAsyncResult ai)
        {
            socket.EndSend(ai);
            socket.BeginReceive(buffer, 0, buffer.Length, 0, ReceiveCallBack, null);
        }

        public void ReceiveCallBack(IAsyncResult ai)
        {

            int CountBytes = socket.EndReceive(ai);

            try
            {
                List<Streat> results;
                BinaryFormatter bf = new BinaryFormatter();

                using (MemoryStream ms = new MemoryStream(buffer))
                    results = bf.Deserialize(ms) as List<Streat>;
                

                if (results.Count == 0)
                {
                    MessageBox.Show("Query does not return any messages");
                    Dispatcher.Invoke(() => { BTN_Find.IsEnabled = true; TB_Index.IsEnabled = true; });
                    return;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var item in results)
                    sb.AppendLine(item.Name);

                MessageBox.Show(sb.ToString());
            }
            catch (Exception e) {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Dispatcher.Invoke(() => { BTN_Find.IsEnabled = true; TB_Index.IsEnabled = true; });
        }

        private void BTN_Find_Click(object sender, RoutedEventArgs e)
        {

            int result;
            if (int.TryParse(TB_Index.Text, out result) && result > 9999 && result < 100000)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.BeginConnect(ServerEndPoint, ConnectCallBack, result);
                BTN_Find.IsEnabled = false;
                TB_Index.IsEnabled = false;
            }
            else
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
