using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MessageLibrary;

namespace AsyncClient
{
    class ClientProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Client";
            Console.Write("Адрес: ");
            string ip = Console.ReadLine();
            Console.Write("Порт: ");
            int port = int.Parse(Console.ReadLine());

            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));

            if (!client.Connected)
            {
                Console.WriteLine("Ошибка подключения!!!");
                Console.ReadKey();
                return;
            }

            MemoryStream ms = new MemoryStream();
            byte[] buf = new byte[1024];
            int len;
            do
            {
                len = client.Receive(buf, buf.Length, SocketFlags.None);
                ms.Write(buf, 0, len);
            } while (client.Available > 0);
            ms.Position = 0;
            LanMessage message = LanMessage.DeserializeMessage(ms.ToArray());
            Console.WriteLine(" >> " + message);

            Console.Write("Введите сообщение: ");
            string s = Console.ReadLine();
            client.Send(LanMessage.SerializeMessage(new LanMessage(s)));

            client.Shutdown(SocketShutdown.Both);
            client.Close();

            Console.WriteLine("\nПодключение закрыто, нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
