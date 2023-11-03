using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Thuvien
{
    public class User
    {
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public int MaSo { get; set; }
        public string SoDT { get; set; }
        public int size;

        public User() { }

        public User(byte [] data)
        {
            int place = 0;

            int hoTenSize = BitConverter.ToInt32(data, place);
            place += 4;
            HoTen = Encoding.UTF8.GetString(data, place, hoTenSize);
            place += hoTenSize;

            int ngaySinhSize = BitConverter.ToInt32(data, place);
            place += 4;
            NgaySinh = Encoding.ASCII.GetString(data, place, ngaySinhSize);
            place += ngaySinhSize;

            MaSo = BitConverter.ToInt32(data, place);
            place += 4;

            int soDTSize = BitConverter.ToInt32(data, place);
            place += 4;
            SoDT = Encoding.ASCII.GetString(data, place, soDTSize);
            place += soDTSize;
        }

        public byte[] GetBytes()
        {
            byte[] data = new byte[1024];
            int place = 0;
            //Gui kich thuoc cua chuoi truoc roi moi gui noi dung
            Buffer.BlockCopy(BitConverter.GetBytes(HoTen.Length),0,data,place,4);
            place += 4;
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(HoTen), 0, data, place, HoTen.Length);//UTF8 co ho tro tieng viet
            place += HoTen.Length;

            Buffer.BlockCopy(BitConverter.GetBytes(NgaySinh.Length), 0, data, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(NgaySinh), 0, data, place, NgaySinh.Length);
            place += NgaySinh.Length;

            Buffer.BlockCopy(BitConverter.GetBytes(MaSo), 0, data, place, 4);
            place += 4;

            Buffer.BlockCopy(BitConverter.GetBytes(SoDT.Length),0,data,place,4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(SoDT), 0, data, place, SoDT.Length);
            place += SoDT.Length;

            size = place;
            return data;
        }

        public void NhapTuBanPhim()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap ngay sinh: ");
            NgaySinh = Console.ReadLine();
            Console.Write("Nhap ma so: ");
            MaSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap so dien thoai: ");
            SoDT = Console.ReadLine();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Ho va ten = {0} ", HoTen));
            sb.AppendLine(string.Format("ngay sinh = {0}", NgaySinh));
            sb.AppendLine(string.Format("Ma so = {0}",MaSo));
            sb.AppendLine(string.Format("So dien thoai = {0}",SoDT));
            return sb.ToString();
        }
    }
    
}
