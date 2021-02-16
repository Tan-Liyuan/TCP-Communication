using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 通讯
{
    public partial class MainForm : Form
    {
        SocketClient client;
        SocketServer server;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void WriteLine(string text, params object[] texts)
        {
            text = string.Format(text, texts);//获取文本

            float length = 280;//获取窗口宽度
            Graphics graphics = infoList.CreateGraphics();//获取图形控件
            infoList.Items.Add("文本总长：" + graphics.MeasureString(text, infoList.Font).Width);
            int pointer = 0;//设置指针
            string sentence = "";//设置单句

            while (pointer < text.Length)
            {
                sentence += text[pointer];
                float width = graphics.MeasureString(sentence, infoList.Font).Width;
                if(width >= length)
                {
                    infoList.Items.Add("本句长度：" + width);
                    infoList.Items.Add(sentence);
                    sentence = "";
                }
                pointer++;
            }
            infoList.Items.Add(sentence);

            //bool isFirstLine = true;
            //while (text.Length > length)
            //{
            //    string firstHalf = text.Substring(0, length);
            //    text = text.Substring(length);
            //    infoList.Items.Add(isFirstLine ? firstHalf : "- " + firstHalf);
            //    isFirstLine = false;
            //}
            //infoList.Items.Add(isFirstLine ? text : "- " + text);
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(portBox.Text, out int port))
            {
                WriteLine("ERROR: 端口号格式错误");
                return;
            }
            try
            {
                if (isClient.Checked)
                {
                    client = new SocketClient(ipBox.Text, port, this);
                    client.StartClient();
                }
                else
                {
                    server = new SocketServer(ipBox.Text, port, this);
                    server.StartListen();
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                if (isClient.Checked) WriteLine("服务器连接失败");
                else WriteLine("服务器创建失败");
            }
        }

        private void CloseAll()
        {
            CloseServer();
            CloseClient();
        }

        private void CloseClient()
        {
            client.receiveThread.Abort();
            if (client != null) client = null;
        }

        private void CloseServer()
        {
            if (server != null)
            {
                server.Close();
                server = null;
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (TextBox.Text.StartsWith("#"))
            {
                infoList.Items.Clear();
            }
            else
            {
                if (client != null)
                {
                    client.SendMessage(TextBox.Text);
                    TextBox.Text = string.Empty;
                }
                else if (server != null)
                {
                    server.SendText("SERVER: " + TextBox.Text);
                    TextBox.Text = string.Empty;
                }
                else
                {
                    WriteLine("ERROR: 还未开启服务器或客户端");
                }
            }

        }

        private void Close_Click(object sender, EventArgs e)
        {
            CloseAll();
        }

        public void ExitProgram(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(portBox.Text, out int port))
            {
                WriteLine("ERROR: 端口号格式错误");
                return;
            }
            else if (server == null)
            {
                WriteLine("ERROR: 服务器还未创建，无法进行端口映射");
                return;
            }
            else
            {
                try
                {
                    server.UPnP(port);
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

    }
}
