using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Server
    {
        static Socket socket;
        static int port = 1000;
        static IPEndPoint ServerEndPoint;
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ServerEndPoint = new IPEndPoint(IPAddress.Any, port);


            socket.Bind(ServerEndPoint);
            socket.Listen(10);



            try
            {
                while (true)
                {
                    Socket ClientSocket =  socket.Accept();


                    Console.WriteLine($"Connection from: {ClientSocket.RemoteEndPoint}");

                    string str = DateTime.Now.ToString();

                    ClientSocket.Send(Encoding.Unicode.GetBytes(str));

                    Console.WriteLine($"Disconnect from: {ClientSocket.RemoteEndPoint}");

                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Close();
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
