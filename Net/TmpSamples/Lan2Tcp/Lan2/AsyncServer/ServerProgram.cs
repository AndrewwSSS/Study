using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncServer
{
    class ServerProgram
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            Console.Write("Введите порт для прослушивания: ");
            int port = int.Parse(Console.ReadLine());

            var server = new AsyncServerClass(port);
            server.IncomingMessage += Server_IncomingMessage;
            Task serverTask = Task.Run(server.StartServer);

            Console.WriteLine("Нажмите ENTER для выхода...");
            Console.ReadLine();
        }

        private static void Server_IncomingMessage(string obj)
        {
            Console.WriteLine(">> " + obj);
        }
    }
}
