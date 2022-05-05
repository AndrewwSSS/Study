using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ClassesLibrary;

namespace AsyncTCPServer
{
    internal class Program
    {
        static Socket socket;
        static int port = 1488;
        public static List<Streat> Streats { get; set; }
        private static XmlSerializer serializer  = new XmlSerializer(typeof(List<Streat>));
        private static byte[] buffer = new byte[8196];


        static void Main(string[] args)
        {
            LoadStreatsFromFile(Directory.GetCurrentDirectory() + @"\Streats.xml");
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(100);
            socket.BeginAccept(AcceptCallBack, socket);

            Console.WriteLine("Server is active");
            Console.ReadKey();
        }


        static private void AcceptCallBack(IAsyncResult ia)
        {
            Socket ClientSocket = socket.EndAccept(ia);

            Console.Write($"\nConnect: {ClientSocket.RemoteEndPoint}");


            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReciveCallBack, ClientSocket);

            socket.BeginAccept(AcceptCallBack, socket);

        }

        static private void ReciveCallBack(IAsyncResult ia)
        {
            Socket ClientSocket = (Socket)ia.AsyncState;

            if (ClientSocket.Connected)
            {
                try
                {
                    int bytesReceived = ClientSocket.EndReceive(ia);
                    byte[] data = new byte[bytesReceived];

                    Array.Copy(buffer, data, bytesReceived);

                    int PostIndex = BitConverter.ToInt32(data, 0);
                    List<Streat> StreatsByIndex = Streats.Where(s => s.PostIndex == PostIndex).ToList();
                    byte[] ToWrite;

                    
                    using (var MemoryStream = new MemoryStream())
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(MemoryStream, StreatsByIndex);
                        ToWrite = MemoryStream.ToArray();
                    }

                    ClientSocket.BeginSend(ToWrite, 0, ToWrite.Length, SocketFlags.None, SendMessageCallBack, ClientSocket);

                }
                catch(Exception ex) {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.Write($"\nDisconnect(emergency) from: {ClientSocket.RemoteEndPoint}");
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Close();
                    
                }
            }

        }

        static private void SendMessageCallBack(IAsyncResult ia)
        {
            Socket ClientSocket = (Socket)ia.AsyncState;
            ClientSocket.EndSend(ia);

            Console.Write($"\nDisconnect from: {ClientSocket.RemoteEndPoint}");

            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();       
        }

        static private bool LoadStreatsFromFile(string FileName)
        {
            try
            {
                using (StreamReader writer = new StreamReader(FileName))
                    Streats = (List<Streat>)serializer.Deserialize(writer);

            }
            catch (Exception) { return false; }
            return true;
       
        }

        static private bool SaveStreatsInFile(string FileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FileName))
                    serializer.Serialize(writer, Streats);
              
            }
            catch (Exception) { return false; }
            return true;
        }

    }
}
