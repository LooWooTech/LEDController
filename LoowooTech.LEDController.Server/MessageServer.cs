﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LoowooTech.LEDController.Server
{
    public class MessageReceivedEventArgs : EventArgs
    {
        public string WinId { get; set; }
        public string Text { get; set; }
    }

    public class ClientStatus
    {
        public Socket Socket { get; set; }
        public Thread Thread { get; set; }
        public byte[] Buffer { get; set; }
        public int ReceivedLength { get; set; }
        public bool Stop { get; set; }

        public ClientStatus()
        {
            Buffer = new byte[1024];
        }
    }

    public class MessageServer
    {
        private static readonly int TimeOut = 500;
        private readonly List<ClientStatus> stateList = new List<ClientStatus>();
        //private readonly Dictionary<string, Queue<string>> messagePool = new Dictionary<string, Queue<string>>();
        private TcpListener listener;
        private readonly IPEndPoint endPoint;

        public event EventHandler<MessageReceivedEventArgs> OnMessageReceived;
        public MessageServer() : this(0, 8081) { }
        public MessageServer(int port) : this(0, port) { }
        public MessageServer(int addressIndex, int port)
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var index = 0;
            IPAddress ipAddress = null;
            foreach (var address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (index == addressIndex)
                    {
                        ipAddress = address;
                    }
                    index++;
                }
            }
            endPoint = new IPEndPoint(ipAddress, port);
        }

        public MessageServer(string address, int port)
        {
            endPoint = new IPEndPoint(IPAddress.Parse(address), port);
        }

        private void WriteLog(string msg)
        {
            File.AppendAllText("log.txt", string.Format("[{0:yyyy-MM-dd HH:mm:ss}] {1}\r\n", DateTime.Now, msg));
        }

        private bool signal = true;
        private Thread thread;

        public void Stop()
        {
            if (signal == false) return;
            lock (stateList)
            {
                foreach (var state in stateList)
                {
                    state.Stop = true;
                }
            }
            signal = false;
            foreach (var stat in stateList)
            {
                if (stat.Thread.IsAlive)
                {
                    if (stat.Thread.Join(1000) == false) stat.Thread.Abort();
                }
            }

            if (thread.IsAlive)
            {
                if (thread.Join(1000) == false) thread.Abort();
            }
            listener.Stop();
        }

        public void Start()
        {
            signal = true;
            thread = new Thread(StartListeningInner);
            thread.Start();
        }

        private void StartListeningInner()
        {
            try
            {
                listener = new TcpListener(endPoint);
                listener.Start();
                WriteLog("[INFO]开始监听:" + endPoint);

                while (signal)
                {
                    try
                    {
                        if (listener.Server.Poll(TimeOut, SelectMode.SelectRead))
                        {
                            if (listener.Pending() == false) continue;

                            var s = listener.AcceptSocket();
                            WriteLog("[INFO]接收客户端:" + s.LocalEndPoint);
                            var clientservice = new Thread(new ParameterizedThreadStart(AcceptSocket));
                            var ip = ((IPEndPoint)s.RemoteEndPoint).Address;

                            var state = new ClientStatus
                            {
                                Socket = s,
                                Thread = clientservice
                            };

                            clientservice.Start(state);
                        }
                    }
                    catch (Exception e)
                    {
                        WriteLog("[ERROR]服务器出现错误：" + e);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("[ERROR]服务器监听错误：" + ex);
            }
        }

        private void GetMessage(ClientStatus status)
        {
            var client = status.Socket;
            if (client.Poll(TimeOut, SelectMode.SelectRead))
            {
                var count = client.Receive(status.Buffer, status.ReceivedLength, status.Buffer.Length - status.ReceivedLength, SocketFlags.None);
                if (count > 0)
                {
                    status.ReceivedLength += count;

                    var message = Encoding.UTF8.GetString(status.Buffer, 0, status.ReceivedLength);
                    var pos = message.IndexOf('@');
                    if (pos > -1)
                    {
                        status.ReceivedLength = 0;
                        var tokens = message.Substring(0, pos).Split('|');
                        if (tokens.Length == 2)
                        {
                            WriteLog(string.Format("[INFO]接收消息: {0}|{1}", tokens[0], tokens[1]));
                            try
                            {
                                OnMessageReceived(this, new MessageReceivedEventArgs { WinId = tokens[0], Text = tokens[1] });
                            }
                            catch (Exception ex)
                            {
                                WriteLog(string.Format("[ERROR]处理消息错误: {0}", ex.Message));
                            }
                        }
                    }
                }
            }
        }

        private void AcceptSocket(object o)
        {
            var state = o as ClientStatus;
            Byte[] buffer = new Byte[1024];
            var ip = ((IPEndPoint)state.Socket.RemoteEndPoint).Address;
            while (!state.Stop)
            {
                try
                {
                    GetMessage(state);
                    Thread.Sleep(30);
                }
                catch (Exception ex)
                {
                    WriteLog("客户端错误:" + ex);
                    break;
                }
            }

            try
            {
                state.Socket.Shutdown(SocketShutdown.Both);
                state.Socket.Close();
            }
            catch
            {

            }

            lock (stateList)
            {
                stateList.Remove(state);
            }
        }
    }
}
