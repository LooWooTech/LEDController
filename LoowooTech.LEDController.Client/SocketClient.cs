using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.Client
{
    public class SendMessage
    {
        private static byte[] result = new byte[1024];
        public SendMessage(string content)
        {
            var serverIp = System.Configuration.ConfigurationManager.AppSettings["server_ip"];
            var ip = serverIp.Split(':')[0];
            var port = int.Parse(serverIp.Split(':')[1]);
            //设定服务器IP地址
            IPAddress ipAddress = IPAddress.Parse(ip);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ipAddress, port)); //配置服务器IP与端口
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
            //通过clientSocket接收数据
            int receiveLength = clientSocket.Receive(result);
            Console.WriteLine("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));
            //通过 clientSocket 发送数据
            try
            {
                clientSocket.Send(Encoding.ASCII.GetBytes(content));
                Console.WriteLine("向服务器发送消息：{0}" + content);
            }
            catch
            {
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
    }
}
