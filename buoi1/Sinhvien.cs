using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buoi1
{
     class Sinhvien
    {
        private string maso;
        private string holot;
        private string ten;
        private string ngaysinh;
        private string phai;
        private string chuyennganh;
        private float diemTB;
        //Propeties : thuộc tính
        public string Maso { get => maso; set => maso = value; }
        public string Holot { get => holot; set => holot = value; }
        public string Ten { get => ten; set => ten = value; }
        public string Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Phai { get => phai; set => phai = value; }
        public string Chuyennganh { get => chuyennganh; set => chuyennganh = value; }
        public float DiemTB { get => diemTB; set => diemTB = value; }
        // Constructor : phương thức khởi tạo
        // Constructor không có đối sồ
        public Sinhvien() { }
        // Constructor có các đối số là thông tin một sinh viên
        public Sinhvien(string ms, string ho, string t, string ns, string ph, string cn,
                        float dtb)
        {
            maso = ms;
            holot = ho;
            ten = t;
            ngaysinh = ns;
            phai = ph;
            chuyennganh = cn;
            diemTB = dtb;
        }
        // Constructor copy : khởi tạo một đối tượng có nội dung từ một đối tượng đã có
        public Sinhvien(Sinhvien sv)
        {
            maso = sv.maso;
            holot = sv.holot;
            ten = sv.ten;
            ngaysinh = sv.ngaysinh;
            phai = sv.phai;
            chuyennganh = sv.chuyennganh;
            diemTB = sv.diemTB;
        }
        public void InputSV()
        {
            Console.WriteLine("Nhập thông tin sinh viên mới :");
            Console.Write("         Mã số : ");
            maso = Console.ReadLine();
            Console.Write("        Họ lót : ");
            holot = Console.ReadLine();
            Console.Write("           Tên : ");
            ten = Console.ReadLine();
            Console.Write("          Phái : ");
            phai = Console.ReadLine();
            Console.Write("     Ngày sinh : ");
            ngaysinh = Console.ReadLine();
            Console.Write("  Chuyên ngành : ");
            chuyennganh = Console.ReadLine();
            Console.Write("       Điểm TB : ");
            diemTB = float.Parse(Console.ReadLine());
        }
        // Phương thức xếp loại, trả về chuổi xếp loại
        public string Xeploai()
        {
            if (diemTB < 5) return "Yếu";
            else if (diemTB < 6.5) return "Trung bình";
            else if (diemTB < 8) return "Khá";
            else return "Giỏi";
        }
        // Xuất thông tin một sinh viên lên màn hình
        public void OutputSV()
        {
            // Xác định xếp loại
            string xl = Xeploai();
            Console.WriteLine(maso.PadRight(10) + holot.PadRight(20) + ten.PadRight(10)
                + ngaysinh.PadRight(12) + phai.PadRight(10) + chuyennganh.PadRight(20)
                + diemTB.ToString().PadLeft(10) + xl.PadLeft(15));
        }

    }
}
