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
    //public class Program
    //{
    //    private static Afgift afgift = new Afgift();
    //    private static TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);

    //    public static void Main(string[] args)
    //    {
    //        serverSocket.Start();
    //        Console.WriteLine("Server started");
    //        AccepterKlienter();

    //    }

    //    private static void AccepterKlienter()
    //    {
    //        while (true)
    //        {
    //            TcpClient newClient = serverSocket.AcceptTcpClient();
    //            Thread t = new Thread(new ParameterizedThreadStart(NyKlient));
    //            t.Start(newClient);
    //        }
    //    }

    //    private static void NyKlient(object obj)
    //    {
    //        TcpClient client = (TcpClient) obj;

    //        Console.WriteLine("Server activated by client");

    //        Stream ns = client.GetStream();

    //        StreamReader sr = new StreamReader(ns);
    //        StreamWriter sw = new StreamWriter(ns);
    //        {
    //            sw.AutoFlush = true;
    //        }

    //        while (true)
    //        {
    //            sw.WriteLine("Vil du vælge personbil eller elbil?");
    //            string msg = sr.ReadLine();

    //            if (msg.ToLower().Contains("person"))
    //            {
    //                sw.WriteLine("Hvad er prisen på personbilen?");
    //                string pris = sr.ReadLine();
    //                sw.WriteLine("Afgift: " + afgift.BilAfgift(Convert.ToInt32(pris))  + " - Tryk enter for ny beregning");
    //                sr.ReadLine();
    //            }

    //            else if (msg.ToLower().Contains("el"))
    //            {
    //                sw.WriteLine("Hvad er prisen på elbilen?");
    //                string pris = sr.ReadLine();
    //                sw.WriteLine("Afgift: " + afgift.ElBilAfgift(Convert.ToInt32(pris)) + " - Tryk enter for ny beregning");
    //                sr.ReadLine();
    //            }
    //        }
    //    }
    //}
}
