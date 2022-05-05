using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MessageLibrary;

namespace AsyncServer
{
    public class AsyncServerClass
    {
        private IPEndPoint localPoint;
        private Socket server;
        public event Action<string> IncomingMessage; // = (s) => { };
        public AsyncServerClass(int port)
        {
            if ((port < 0) || (port >= 65535))
                throw new ArgumentOutOfRangeException("Порт указан неверно!!!");
            
            server = null;
            localPoint = new IPEndPoint(IPAddress.Any, port);
        }

        public void StartServer()
        {
            if (server != null)
                return;

            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(localPoint);
            server.Listen(10);

            server.BeginAccept(AcceptCallback, server);
            
            //if (IncomingMessage != null)
                //IncomingMessage("Сервер запущен");

            IncomingMessage?.Invoke("Сервер запущен");
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket srv = ar.AsyncState as Socket;
            Socket client = srv.EndAccept(ar);
            IncomingMessage?.Invoke("Подключение: " + client.RemoteEndPoint.ToString());

            Task.Run(() =>
            {
                ClientConnection(client);
            });

            srv.BeginAccept(AcceptCallback, srv);
        }

        private void ClientConnection(Socket client)
        {
            client.Send(LanMessage.SerializeMessage(new LanMessage("Привет")));
            MemoryStream ms = new MemoryStream();
            byte[] buf = new byte[1024];
            int len;
            do
            {
                len = client.Receive(buf, buf.Length, SocketFlags.None);
                ms.Write(buf, 0, len);
            } while (client.Available > 0);

            IncomingMessage?.Invoke(client.RemoteEndPoint.ToString() + ": " 
                + LanMessage.DeserializeMessage(ms.ToArray()).ToString());
            
            client.Shutdown(SocketShutdown.Send);
            client.Close();
        }
    }
}
