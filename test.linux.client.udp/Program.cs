using socket.core.Client;
using System;
using System.Net;
using System.Text;
using System.Threading;

namespace test.linux.client.udp
{
    class Program
    {
        static UdpClients udpclient;
        static void Main(string[] args)
        {
            udpclient = new UdpClients(1024);
            udpclient.Start("127.0.0.1", 6666);
            udpclient.OnReceive += UdpServer_OnReceive;
            udpclient.OnSend += UdpServer_OnSend;
            byte[] arg2 = Encoding.UTF8.GetBytes("fdsafdsafdsafdsafdasfdsafffdsafdsafdsafdsafdasfdsaffdsafdsafdsafdsafdasfdsaffdsafaaadsafdsafdsafdasfdsaffdsafdsafdsafdsafdasfdsafdsafdsafdsafdsafdasfdsaffdsafdsafdsafdsafdasfdsaffdsafdsafdsafdsafdasfdsaf");
            for (int i = 0; i < int.MaxValue; i++)
            {
                udpclient.Send(arg2,0, arg2.Length);
                Thread.Sleep(1);
            }
            Console.Read();
        }

        private static void UdpServer_OnSend(int arg2)
        {
            //Console.WriteLine("客户端发送长度：" + arg2);
        }
        static int i = 0;
        private static void UdpServer_OnReceive(byte[] arg2, int arg3, int arg4)
        {
            Console.WriteLine(i++ +"客户端接收长度：" + arg4);
            //udpServer.Send( arg2, arg3, arg4);
        }
    }
}
