using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Thuvien;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Thuvien.User user1 = new Thuvien.User();
            user1.NhapTuBanPhim();
            TcpClient client;
            try
            {
                client = new TcpClient("127.0.0.1", 9050);
            }
            catch(SocketException)
            {
                Console.WriteLine("Khong ket noi duoc voi Server");
                return;
            }
            NetworkStream ns = client.GetStream();
            byte[] data = user1.GetBytes();
            int size = user1.size;
            byte[] packsize = new byte[2];
            Console.WriteLine("Kich thuoc goi tin = {0}", size);
            packsize = BitConverter.GetBytes(size);
            ns.Write(packsize, 0, 2);
            ns.Write(data, 0, size);
            ns.Flush();

            ns.Close();
            client.Close();

            Console.ReadKey();
        }
    }
}
