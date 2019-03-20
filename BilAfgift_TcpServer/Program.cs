using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using BilAfgiftLibrary;

namespace BilAfgift_TcpServer
{
    public class Program
    {
        public static TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);


        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("192.168.0.13");

            Console.WriteLine("Server Starter");
            serverSocket.Start();

            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();

                TcpServerService service = new TcpServerService(connectionSocket);
                Task.Factory.StartNew(() => service.DoIt());
            }




            serverSocket.Stop();
        }
    }
}
