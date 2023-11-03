using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] data = new byte[1024];
            TcpListener server = new TcpListener(IPAddress.Any, 9050);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            byte[] size = new byte[2];
            int recv = ns.Read(size, 0, 2);
            int packsize = BitConverter.ToInt16(size, 0);
            Console.WriteLine("Kich thuoc goi tin = {0}", packsize);
            recv = ns.Read(data, 0, packsize);
            Thuvien.User user1 = new Thuvien.User(data);
            Console.WriteLine(user1);

            ns.Close();
            client.Close();
            server.Stop();

            Console.ReadKey();
            
        }
    }
}
