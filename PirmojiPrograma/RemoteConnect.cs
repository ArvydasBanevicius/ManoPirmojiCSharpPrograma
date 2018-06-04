using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

//http://csharp.net-informations.com/communications/csharp-client-socket.htm

namespace PirmojiPrograma
{
    class RemoteConnect: TcpClient
    {
        NetworkStream serverStream;

        public string Host { get; set; }
        public int Port { get; set; }
        public bool IsConnected { get; set; }

        public bool OpenSocket
        {
            get { return IsConnected; }
            set { IsConnected = value; }
        }

        public byte[] ReadData()
        {
            
            byte[] inStream = new byte[1500];
            serverStream.Read(inStream, 0, (int)ReceiveBufferSize);
            //string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            return inStream;
        }

        public void SendData( byte[] Buff)
        {
            //byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            serverStream.Write(Buff, 0, Buff.Length);
            serverStream.Flush();
        }

        public RemoteConnect()
        {
            serverStream = GetStream();
        }
    }
}
