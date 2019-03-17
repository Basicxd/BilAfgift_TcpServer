using System;
using System.Net;
using System.Net.Sockets;

namespace BilAfgift_TcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("192.168.0.13");
            TcpListener serverSocket = new TcpListener(ip, 6789);

            Console.WriteLine("Server Starter");
            serverSocket.Start();

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Server aktiveret");

            Console.ReadLine();

            connectionSocket.Close();
            serverSocket.Stop();
        }
    }
}
