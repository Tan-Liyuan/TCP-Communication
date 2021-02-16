using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using NATUPNPLib;
using System.Linq;
using System.Text.RegularExpressions;

namespace 通讯
{
    class SocketServer
    {
        private MainForm form;
        private Thread listenThread;
        private List<Thread> clientThreads;
        private List<Socket> clientSockets;

        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">监听的IP</param>
        /// <param name="port">监听的端口</param>
        public SocketServer(string ip, int port, MainForm form)
        {
            if (ip == string.Empty) ip = "0.0.0.0";
            this.form = form;
            this._ip = ip;
            this._port = port;
            clientThreads = new List<Thread>();
            clientSockets = new List<Socket>();
        }

        public void StartListen()
        {
            try
            {
                //1.0 实例化套接字(IP4寻找协议,流式协议,TCP协议)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                IPAddress address = IPAddress.Parse(_ip);
                //3.0 创建网络端口,包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                //4.0 绑定套接字
                _socket.Bind(endPoint);
                //5.0 设置最大连接数
                _socket.Listen(int.MaxValue);
                form.WriteLine("SYSTEM: 服务器创建成功 [{0}]", _socket.LocalEndPoint.ToString());
                //6.0 开始监听
                listenThread = new Thread(ListenClientConnect);
                listenThread.Start();
            }
            catch (Exception e)
            {
                form.WriteLine(e.Message);
            }
        }

        public void UPnP(int port)
        {
            //获取Host Name
            var name = Dns.GetHostName();
            form.WriteLine("用户名：" + name);
            //从当前Host Name解析IP地址，筛选IPv4地址是本机的内网IP地址。
            var ipv4 = Dns.GetHostEntry(name).AddressList.Where(i => i.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            form.WriteLine("内网IP：" + ipv4);

            form.WriteLine("开始设置UPnP");
            //UPnP绑定信息
            var description = "Mgen测试";
            //创建COM类型
            var upnpnat = new UPnPNAT();
            var mappings = upnpnat.StaticPortMappingCollection;
            //错误判断
            if (mappings == null)
            {
                throw new Exception("没有检测到路由器，或者路由器不支持UPnP功能。");
            }
            //添加之前的ipv4变量（内网IP），内部端口，和外部端口
            mappings.Add(port, "TCP", port, ipv4.ToString(), true, description);//System.Runtime.InteropServices.COMException
            form.WriteLine("外部端口：{0}", port);
            form.WriteLine("内部端口：{0}", port);
            //外网IP变量
            string eip;
            //正则
            var regex = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            using (var webclient = new WebClient())
            {
                var rawRes = webclient.DownloadString("http://checkip.dyndns.org/");
                eip = Regex.Match(rawRes, regex).Value;
            }
            form.WriteLine("外网IP：" + eip);
        }


        public void Close()
        {
            for(int i = 0; i < clientSockets.Count; i++)
            {
                clientThreads[i].Abort();
                clientSockets[i].Send(Encoding.UTF8.GetBytes("SYSTEM: 服务器已关闭"));
                clientSockets[i].Close();
            }
            listenThread.Abort();
        }

        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private void ListenClientConnect()
        {
            try
            {
                while (true)
                {
                    //Socket创建的新连接
                    Socket clientSocket = _socket.Accept();
                    Thread thread = new Thread(ReceiveMessage);
                    thread.Start(clientSocket);
                    clientThreads.Add(thread);
                    clientSockets.Add(clientSocket);
                }
            }
            catch (Exception e)
            {
                form.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 接收客户端消息
        /// </summary>
        /// <param name="socket">来自客户端的socket</param>
        private void ReceiveMessage(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (true)
            {
                try
                {
                    //获取从客户端发来的数据
                    int length = clientSocket.Receive(buffer);
                    SendText(clientSocket.RemoteEndPoint.ToString()+": "+Encoding.UTF8.GetString(buffer, 0, length));
                    //form.WriteLine("接收客户端{0},消息{1}", clientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                }
                catch (Exception e)
                {
                    form.WriteLine(e.Message);
                    //clientSocket.Shutdown(SocketShutdown.Both);
                    //clientSocket.Close();
                    break;
                }
            }
        }

        public void SendText(string text, params object[] texts)
        {
            SendText(string.Format(text, texts));
        }

        public void SendText(string message)
        {
            form.WriteLine(message);
            foreach(Socket client in clientSockets)
            {
                try
                {
                    client.Send(Encoding.UTF8.GetBytes(message));
                }
                catch (Exception e)
                {
                    form.WriteLine(e.Message);
                }
            }
        }
    }
}
