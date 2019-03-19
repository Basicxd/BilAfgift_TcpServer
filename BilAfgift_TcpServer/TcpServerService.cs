using System;
using System.IO;
using System.Net.Sockets;
using BilAfgiftLibrary;

namespace BilAfgift_TcpServer
{
    public class TcpServerService
    {
        private static Afgift afgift = new Afgift();

        private TcpClient connectionSocket;

        public TcpServerService(TcpClient connectionSocket)
        {
            this.connectionSocket = connectionSocket;
        }
        internal void DoIt()
        {
            Console.WriteLine("Klient Joined");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            while (true)
            {
                sw.WriteLine("Vil du vælge personbil eller elbil?");
                string msg = sr.ReadLine();

                if (msg.ToLower().ToUpper().Contains("person"))
                {
                    sw.WriteLine("Hvad er prisen på personbilen?");
                    string pris = sr.ReadLine();
                    sw.WriteLine("Afgift: " + afgift.BilAfgift(Convert.ToInt32(pris)) + " - Tryk enter for ny beregning");
                    sr.ReadLine();
                }
                else if (msg.ToLower().ToUpper().Contains("el"))
                {
                    sw.WriteLine("Hvad er prisen på elbilen?");
                    string pris = sr.ReadLine();
                    sw.WriteLine("Afgift: " + afgift.ElBilAfgift(Convert.ToInt32(pris)) +" - Tryk enter for ny beregning");
                    sr.ReadLine();
                }
            }
            ns.Close();
            connectionSocket.Close();
        }
    }
}