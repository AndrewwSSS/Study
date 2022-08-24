using ClassesLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Server
{
    public class Program
    {
        public static Socket socket { get; set; }
        public static int port { get; set; } = 1234;
        public static List<Recipe> Recipes { get; set; } = new List<Recipe>();
        public static XmlSerializer serializer { get; set; } = new XmlSerializer(typeof(List<Recipe>));



        static void Main(string[] args)
        {

            OpenFromFile(Directory.GetCurrentDirectory() + @"\Recipes.xml");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(100);

            socket.BeginAccept(AcceptCallBack, null);

            Console.Write("\nServer is active");
            Console.ReadKey();

        }


        static void AcceptCallBack(IAsyncResult ai)
        {
            Socket ClientSocket;
            try
            {
                ClientSocket = socket.EndAccept(ai);
            }catch (Exception ex) {
                Console.Write($"\nError: {ex.Message}");
                return; 
            }

            Console.Write($"\nConnect from: {ClientSocket.RemoteEndPoint}");

            socket.BeginAccept(AcceptCallBack, null);

            byte[] buffer = new byte[8192];
            ClientSocket.BeginReceive(buffer, 0, 8192, 0, ReceiveCallBack, new List<object> { ClientSocket, buffer});

            
        }

        static void ReceiveCallBack(IAsyncResult ai)
        {
            List<object> arguments = (List<object>)ai.AsyncState;
            Socket ClientSocket = (Socket)arguments[0];
            byte[] buffer = (byte[])arguments[1];

            ClientSocket.EndReceive(ai);

            if (ClientSocket.Available > 0)
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(buffer, 0, buffer.Length);

                byte[] tmpBuffer = new byte[1024];

                while (true)
                {
                    int ReadBytes = ClientSocket.Receive(tmpBuffer, 1024, 0);

                    if (ClientSocket.Available == 0)
                        break;

                    ms.Write(tmpBuffer, 0, ReadBytes);
                }
                    
                buffer = ms.ToArray();

               
            }

            List<string> RequestIngredientsNames;
           
            using(MemoryStream ms = new MemoryStream(buffer))
            {

               
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    RequestIngredientsNames = (List<string>)bf.Deserialize(ms);
                }catch(Exception ex)
                {
                    Console.Write($"\n Error: {ex.Message}");
                    return;
                }    
            }

            List<Recipe> RecipesByRequest = new List<Recipe>();

            if (RequestIngredientsNames.Count == 0)
            {
                RecipesByRequest = new List<Recipe>();
            }
            else
                RecipesByRequest =
                  Recipes.Where(r => RequestIngredientsNames.Count(ri => r.Ingredients.Count(i => i.Ingredient.Name.ToLower() == ri.ToLower()) == 1) > 0).Distinct().ToList();


            byte[] ToSend;

      
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, RecipesByRequest);
                ToSend = ms.ToArray();
            }

            ClientSocket.BeginSend(ToSend, 0, ToSend.Length, 0, SendCallBack, ClientSocket);
        }

        static void SendCallBack(IAsyncResult ai)
        {
            Socket ClientSocket = (Socket)ai.AsyncState;
            try
            {
                ClientSocket.EndSend(ai);
            }catch(Exception ex) { Console.Write($"\nError: {ex.Message}"); }
         

            Console.Write($"\nDisconnect from: {ClientSocket.RemoteEndPoint}");


            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }

        static bool SaveToFile(string FileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                    serializer.Serialize(writer, Recipes);

            }catch { return false; }
            return true;


        }


        static bool OpenFromFile(string FileName)
        {

            try
            {
                using (StreamReader reader = new StreamReader(FileName))
                    Recipes = (List<Recipe>)serializer.Deserialize(reader);

            }
            catch { return false; }
            return true;


        }
    }
}
