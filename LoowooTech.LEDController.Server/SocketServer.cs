using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.Server
{
    public class SocketServer
    {
        private static byte[] result = new byte[1024];
        static Socket serverSocket;
        public SocketServer(int port = 8080)
        {
            //服务器IP地址
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, port));  //绑定IP地址：端口
            serverSocket.Listen(10);    //设定最多10个排队连接请求
            Console.WriteLine("启动监听{0}成功", serverSocket.LocalEndPoint.ToString());
            //通过Clientsoket发送数据
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
            Console.ReadLine();
        }

        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private static void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                clientSocket.Send(Encoding.ASCII.GetBytes("Hi"));
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="clientSocket"></param>
        private static void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据
                    var receiveNumber = myClientSocket.Receive(result);
                    var data = Encoding.ASCII.GetString(result, 0, receiveNumber);
                    Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), data);
                    //Call API

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myClientSocket.Shutdown(SocketShutdown.Both);
                    myClientSocket.Close();
                    break;
                }
            }
        }
        //private Thread serverThread;
        //private Thread clientThread;
        //private TcpListener serverTcp;
        //private TcpClient clientTcp;

        //private void ServerStart()
        //{
        //    //创建IPEndPoint实例
        //    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 6001);
        //    /*
        //    //创建一个套接字
        //    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //    //将所创建的套接字与IPEndPoint绑定
        //    serverSocket.Bind(ipep);
        //    //设置套接字为收听模式
        //    serverSocket.Listen(10);
        //    */
        //    serverTcp = new TcpListener(ipep);
        //    serverTcp.Start();

        //    while (true)
        //    {
        //        try
        //        {
        //            //在套接字上接收接入的连接
        //            while (!serverTcp.Pending())
        //            {
        //                Thread.Sleep(1000);
        //            }
        //            //clientSocket = serverSocket.Accept();
        //            clientTcp = serverTcp.AcceptTcpClient();
        //            //clientThread = new Thread(new ThreadStart(ReceiveData));
        //            //clientThread.Start();
        //            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveData));
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("listening Error: " + ex.Message);
        //        }
        //    }
        //}

        //private void ReceiveData(object state)
        //{
        //    bool keepalive = true;
        //    TcpClient s = clientTcp;
        //    NetworkStream ns = s.GetStream();
        //    StreamReader sr = new StreamReader(ns);
        //    StreamWriter sw = new StreamWriter(ns);

        //    //Byte[] buffer = new Byte[1024];

        //    //根据收听到的客户端套接字向客户端发送信息
        //    IPEndPoint clientep = (IPEndPoint)s.Client.RemoteEndPoint;

        //    string welcome = "Welcome to my test sever ";
        //    //byte[] data = new byte[1024];
        //    //data = Encoding.ASCII.GetBytes(welcome);
        //    //s.Send(data, data.Length, SocketFlags.None);
        //    //ns.Write(data,0, data.Length);
        //    sw.WriteLine(welcome);
        //    sw.Flush();

        //    string data = "";
        //    while (keepalive)
        //    {
        //        //在套接字上接收客户端发送的信息
        //        int bufLen = 0;
        //        try
        //        {
        //            //bufLen = s.Available;
        //            //s.Receive(buffer, 0, bufLen, SocketFlags.None);
        //            //ns.Read(buffer, 0, bufLen);
        //            data = sr.ReadLine();
        //            if (data == "")
        //                continue;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Receive Error:" + ex.Message);
        //            return;
        //        }
        //        clientep = (IPEndPoint)s.Client.RemoteEndPoint;
        //        //string clientcommand = System.Text.Encoding.ASCII.GetString(buffer).Substring(0, bufLen);

        //    }

        //}
    }
}
