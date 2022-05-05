using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Client
    {
        static Socket socket;
        static IPAddress ServerIP = IPAddress.Parse("26.246.72.11");
        static int port = 1000;
        static IPEndPoint ServerEndPoint = new IPEndPoint(ServerIP, port);


        static void Main(string[] args)
        {
            while (true)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                Console.Write("Press any key to request time from the server...");
                Console.ReadKey();
                Console.WriteLine();

                try
                {
                    socket.Connect(ServerEndPoint);

                    if (socket.Connected)
                    {


                        byte[] buffer = new byte[1024];
                        int l;

                        StringBuilder sb = new StringBuilder();

                        do
                        {
                            l = socket.Receive(buffer);


                            if (l == 0)
                                continue;

                            sb.Append(Encoding.Unicode.GetString(buffer, 0, l));
                                               
                        }while (l > 0);

                        sb.AppendLine();
                        Console.WriteLine(sb.ToString());

                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();

                    }
                    
                }
                catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }
        

        }
    }
}
