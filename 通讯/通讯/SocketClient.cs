using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace 通讯
{
    public class SocketClient
    {
        private MainForm form;
        public Thread receiveThread;

        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">连接服务器的IP</param>
        /// <param name="port">连接服务器的端口</param>
        public SocketClient(string ip, int port, MainForm form)
        {
            if (ip == string.Empty) ip = "127.0.0.1";
            form.WriteLine(ip);
            this.form = form;
            this._ip = ip;
            this._port = port;
        }

        /// <summary>
        /// 开启服务,连接服务端
        /// </summary>
        public void StartClient()
        {
            try
            {
                //1.0 实例化套接字(IP4寻址地址,流式传输,TCP协议)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                IPAddress address = IPAddress.Parse(_ip);
                //3.0 创建网络端口包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                //4.0 建立连接
                _socket.Connect(endPoint);
                form.WriteLine("SYSTEM: 连接服务器成功");
                //5.0 接收数据
                receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(_socket);
            }
            catch (Exception ex)
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
                form.WriteLine("ERROR: " + ex.Message);
            }
        }

        private void ReceiveMessage(object socket)
        {
            Socket serverSocket = (Socket)socket;
            while (true)
            {
                try
                {
                    //获取从服务端发来的数据
                    int length = serverSocket.Receive(buffer);
                    form.WriteLine(Encoding.UTF8.GetString(buffer, 0, length));
                }
                catch (Exception e)
                {
                    form.WriteLine("ERROR: "+e.Message);
                    serverSocket.Shutdown(SocketShutdown.Both);
                    serverSocket.Close();
                    break;
                }
            }
        }

        public void SendMessage(string message)
        {
            _socket.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
