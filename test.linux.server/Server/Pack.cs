﻿using socket.core.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace test.linux.server.Server
{
    public class Pack
    {
        TcpPackServer server;
        /// <summary>
        /// 设置基本配置
        /// </summary>   
        /// <param name="numConnections">同时处理的最大连接数</param>
        /// <param name="receiveBufferSize">用于每个套接字I/O操作的缓冲区大小(接收端)</param>
        /// <param name="overtime">超时时长,单位秒.(每10秒检查一次)，当值为0时，不设置超时</param>
        /// <param name="port">端口</param>
        /// <param name="headerFlag">包头</param>
        public Pack(int numConnections, int receiveBufferSize, int overtime, int port, uint headerFlag)
        {
            server = new TcpPackServer(numConnections, receiveBufferSize, overtime, headerFlag);
            server.OnAccept += Server_OnAccept;
            server.OnReceive += Server_OnReceive;
            server.OnSend += Server_OnSend;
            server.OnClose += Server_OnClose;
            server.Start(port);
        }

        private void Server_OnAccept(Socket socket, int obj)
        {
            //server.SetAttached(obj, 555);
            //Console.WriteLine($"Pack已连接{obj}");
        }

        private void Server_OnSend(int arg1, int arg2)
        {
            //Console.WriteLine($"Pack已发送:{arg1} 长度:{arg2}");
        }

        private void Server_OnReceive(int arg1, byte[] arg2)
        {
            //int aaa = server.GetAttached<int>(arg1);
            //Console.WriteLine($"Pack已接收:{arg1} 长度:{arg2.Length}");
            server.Send(arg1, arg2, 0, arg2.Length);
        }

        private void Server_OnClose(int obj)
        {
            //int aaa = server.GetAttached<int>(obj);
            //Console.WriteLine($"Pack断开{obj}");
        }
    }
}
