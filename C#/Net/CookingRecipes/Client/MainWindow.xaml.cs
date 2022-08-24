using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using ClassesLibrary;

namespace Client
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Ingredients { get; set; } = new ObservableCollection<string>();
        public Socket socket;
        public IPEndPoint ServerEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            LB_Ingredients.ItemsSource = Ingredients;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void BTN_DelIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (LB_Ingredients.SelectedIndex == -1)
            {
                MessageBox.Show("Selected index out of range", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => { BTN_AddIngredient.IsEnabled = true; BTN_DelIngredient.IsEnabled = true; BTN_FindReipes.IsEnabled = true; });
                return;
            }

            Ingredients.Remove((string)LB_Ingredients.SelectedItem);

        }

      

        private void ConnectCallBack(IAsyncResult ai)
        {
            try
            {
                socket.EndConnect(ai);
            }catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => { BTN_AddIngredient.IsEnabled = true; BTN_DelIngredient.IsEnabled = true; BTN_FindReipes.IsEnabled = true; });
                return;
            }

            List<string> Ingredients = (List<string>)ai.AsyncState;


            byte[] ToSend;
            
            using(MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, Ingredients);
                ToSend = ms.ToArray();
            }

            socket.BeginSend(ToSend, 0, ToSend.Length, 0, SendCallBack, null);
        }

        private void SendCallBack(IAsyncResult ai)
        {
            try
            {
                socket.EndSend(ai);
            }
            catch(Exception)
            {
                MessageBox.Show("Fail send message to server", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => { BTN_AddIngredient.IsEnabled = true; BTN_DelIngredient.IsEnabled = true; BTN_FindReipes.IsEnabled = true; });
                return;
            }

            byte[] buffer = new byte[8192];

            socket.BeginReceive(buffer, 0, 8192, 0, ReceiveCallBack, buffer);
        }

        private void ReceiveCallBack(IAsyncResult ai)
        {
            try
            {
                socket.EndReceive(ai);
            }
            catch(Exception)
            {
                MessageBox.Show("Fail receive message from server", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Dispatcher.Invoke(() => { BTN_AddIngredient.IsEnabled = true; BTN_DelIngredient.IsEnabled = true; BTN_FindReipes.IsEnabled = true; });
                return;
            }




            byte[] buffer = (byte[])ai.AsyncState;

            if(socket.Available > 0)
            {
                
                MemoryStream ms = new MemoryStream();
                byte[] tmpBuffer = new byte[1024];

                ms.Write(buffer, 0, buffer.Length);

                while (true)
                {
                    int ReadedBytes = socket.Receive(tmpBuffer, 1024, 0);

                    if(ReadedBytes == 0)
                        break;

                    ms.Write(tmpBuffer, 0, ReadedBytes);

                }


                buffer = ms.ToArray();  
                ms.Dispose();
            }

            List<Recipe> Recipes;

            using(MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Recipes = (List<Recipe>)bf.Deserialize(ms);

            }




            if (Recipes.Count == 0) {
                MessageBox.Show("Server dont finded any recipes");
                return;
            }

            StringBuilder sb = new StringBuilder();
            
            foreach(Recipe recipe in Recipes)
                sb.AppendLine(recipe.Name);

            MessageBox.Show(sb.ToString());
            MessageBox.Show(Recipes.Count.ToString());

            socket.Disconnect(true);
            Dispatcher.Invoke(() => { BTN_AddIngredient.IsEnabled = true; BTN_DelIngredient.IsEnabled = true; BTN_FindReipes.IsEnabled = true; });

        }


        private void BTN_AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_AddIngerdient.Text))
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Ingredients.Add(TB_AddIngerdient.Text);
            TB_AddIngerdient.Text = String.Empty;

        }

        private void BTN_FindReipes_Click(object sender, RoutedEventArgs e)
        {
            BTN_AddIngredient.IsEnabled = false;
            BTN_DelIngredient.IsEnabled = false;
            BTN_FindReipes.IsEnabled = false;

            socket.BeginConnect(ServerEndPoint, ConnectCallBack, Ingredients.ToList());
        }
    }
}
