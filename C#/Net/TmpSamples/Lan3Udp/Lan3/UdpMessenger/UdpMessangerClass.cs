using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UdpMessenger
{
    public class UdpMessangerClass
    {
        private int portLocal;
        private int portRemote;
        private string remoteIp;

        // адрес для прослушивания
        private IPEndPoint localEndpoint;
        // адрес для отправки
        private IPEndPoint remoteEndpoint;
        // адрес отправителя
        private EndPoint receiveEndpoint;

        private Socket serverUdp;

        private byte[] buffer;

        public event Action<string> IncomingMessage;

        public UdpMessangerClass(int portLocal, int portRemote, string remoteIp)
        {
            this.portLocal = portLocal;
            this.portRemote = portRemote;
            this.remoteIp = remoteIp;

            // адрес для прослушивания
            localEndpoint = new IPEndPoint(IPAddress.Any, portLocal);
            // адрес для отправки
            remoteEndpoint =new IPEndPoint(IPAddress.Parse(remoteIp), portRemote);
            serverUdp = null;
        }
        public void StartListening()
        {
            if (serverUdp != null)
                return;

            serverUdp = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            serverUdp.Bind(localEndpoint);

            buffer = new byte[1024];
            receiveEndpoint = new IPEndPoint(IPAddress.Any, 0);
            serverUdp.BeginReceiveFrom(buffer, 0, buffer.Length, 
                SocketFlags.None, ref receiveEndpoint, 
                AsyncReceiveCallback, serverUdp);
        }
        public static string GetString(byte[] buf, int len) => Encoding.UTF8.GetString(buf, 0, len); 
        public static byte[] GetBytes(string text) => Encoding.UTF8.GetBytes(text);
        private void AsyncReceiveCallback(IAsyncResult ar)
        {
            Socket server = ar.AsyncState as Socket;
            int n = server.EndReceiveFrom(ar, ref receiveEndpoint);

            IncomingMessage?.Invoke($"from {receiveEndpoint} at {DateTime.Now.ToLongTimeString()}: {GetString(buffer, n)}");
            
            //buffer = new byte[1024];
            //receiveEndpoint = new IPEndPoint(IPAddress.Any, 0);
            server.BeginReceiveFrom(buffer, 0, buffer.Length,
                SocketFlags.None, ref receiveEndpoint,
                AsyncReceiveCallback, server);
        }

        public void SendMessage(string text)
        {
            if (serverUdp == null)
                return;

            byte[] b = GetBytes(text);
            serverUdp.BeginSendTo(b, 0, b.Length, SocketFlags.None, remoteEndpoint, AsyncSendTo, serverUdp);
        }

        private void AsyncSendTo(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            int n = socket.EndSendTo(ar);
        }
    }
}
