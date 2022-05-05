using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpMessenger
{
    class UdpMessengerProgram
    {
        static void Main(string[] args)
        {
            int portLocal;
            int portRemote;
            string remoteIp;
            Console.Write("Введите порт для прослушивания: ");
            portLocal = int.Parse(Console.ReadLine());
            Console.Write("Введите порт для отправки: ");
            portRemote = int.Parse(Console.ReadLine());
            Console.Write("Введите ip для отправки: ");
            remoteIp = Console.ReadLine();

            UdpMessangerClass udpMessanger = new UdpMessangerClass(portLocal, portRemote, remoteIp);
            udpMessanger.IncomingMessage += UdpMessanger_IncomingMessage;
            udpMessanger.StartListening();

            string message;

            do
            {
                Console.Write("Введите сообщение: ");
                message = Console.ReadLine();
                if (message.CompareTo("exit") == 0)
                    break;
                else
                    udpMessanger.SendMessage(message);

            } while (message != "exit");
        }

        private static void UdpMessanger_IncomingMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
