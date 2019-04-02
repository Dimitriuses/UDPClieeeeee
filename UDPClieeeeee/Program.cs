using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPClieeeeee
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(new ThreadStart(StartSender));
            myThread.Start();
            Thread myThread1 = new Thread(new ThreadStart(StartSender));
            myThread1.Start();
            Thread myThread2 = new Thread(new ThreadStart(StartSender));
            myThread2.Start();
            Thread myThread3 = new Thread(new ThreadStart(StartSender));
            myThread3.Start();
            //StartSender();
        }
        private static void StartSender()
        {
            
            
            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("10.7.180.101"); //ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12000);

                bool done = false;
                while (!done)
                {
                    //Console.WriteLine("Enter msg for Server:");
                    string mes = "Dmitrius"; //Console.ReadLine();
                    byte[] sendbuf = Encoding.ASCII.GetBytes(mes);
                    s.SendTo(sendbuf, remoteEP);
                    //Console.WriteLine("Message sent to the broadcast address");
                    if (mes == "exit")
                    {
                        done = true;
                    }
                }
            }
        }
    }
}
