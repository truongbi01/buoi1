using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace buoi1
{
    internal class DSSV
    {
        // Thành phần : là danh sách các phần tử sinh viên
        Sinhvien[] lst;
        // Propeties
        public Sinhvien[] Lst { get => lst; set => lst = value; }
        // Constructor
        //Constructor không đối số, cấp phát vùng nhớ
        public DSSV()
        { }
        // Đọc file văn bản filePath (DSSV.txt) ra danh sách lst
        public void FileToList(string filePath)
        {
            string[] lines;
            if (File.Exists(filePath)) // kiểm tra sự tồn tại của file
            {	   // Đọc các dòng trong file  array lines
                lines = File.ReadAllLines(filePath);
                // Tạo ds sinh viên
                lst = new Sinhvien[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] s = lines[i].Split('\t');
                    string ms = s[0]; string ho = s[1];
                    string t = s[2]; string ns = s[3];
                    string ph = s[4]; string cn = s[5];
                    float dtb = float.Parse(s[6]);
                    // Khởi tạo một đối tượng sinh viên
                    Sinhvien sv = new Sinhvien(ms, ho, t, ns, ph, cn, dtb);
                    // Đưa vào danh sách lst
                    lst[i] = sv;
                }
            }
            else
            {
                Console.WriteLine("  Không tìm thấy File DSSV.txt");
            }
        }
        // Xuất header của danh sách gồm tên danh sách và các tiêu đề cột
        public void PrintTitle()
        {
            Console.WriteLine();
            Console.WriteLine("     DANH SACH SINH VIEN");
            Console.WriteLine(new string('─', 110));
            Console.WriteLine("Mã SV".PadRight(10) + "Họ lót".PadRight(20) + "Tên".PadRight(10)
                + "Ngày sinh".PadRight(12) + "Phái".PadRight(10) + "Chuyên Nghành".PadRight(20)
                + "Điểm TB".ToString().PadLeft(10) + "Xếp loại".PadLeft(15));
            Console.WriteLine(new string('─', 110));
        }
        // Xuất danh sách lst lên màn hình
        public void PrintDSSV()
        {
            PrintTitle();   // In tiêu đề lên màn hình
            // Duyệt từng phần tử trong danh sách lst và xuất lên màn hình
            for (int i = 0; i < lst.Length; i++)
                lst[i].OutputSV();  // gọi phương thức OutputSV() trong class Sinhvien
            Console.WriteLine(new string('─', 110));
            Console.WriteLine("    Danh sách có {0} sinh viên", lst.Length);
        }
        // Thêm một sinh viên mới
        public void AddNewSV()
        {
            // Khởi tạo một sv mới
            Sinhvien sv = new Sinhvien();
            // Nhập thông tin sinh viên
            sv.InputSV();
            // Cấp phát thêm vùng nhớ cho lst và Đưa sv vào danh sách
            Array.Resize(ref lst, lst.Length + 1);
            lst[lst.Length - 1] = sv; ;
        }
        // Tìm sv trong lst khi biết mã SV
        // Nếu có trả về vị trí tìm thấy, ngược lại trả về -1
        public int FindSV(string ma)
        {
            for (int i = 0; i < lst.Length; i++)
                if (lst[i].Maso == ma)
                    return i;
            return -1;
        }
        // Sửa điểm sv tại vị trí thứ k
        public void UpdateD(int k)
        {
            Console.Write("  Nhap Diem TB moi : ");
            float diem = float.Parse(Console.ReadLine());
            // vì ngoài class Sinhvien nên gán diểm thông qua thuộc tính DiemTB
            lst[k].DiemTB = diem;
        }
        // Xóa sv tại vị trí thứ k
        public void DeleteSV(int k)
        {
            for (int i = k; i < lst.Length - 1; i++)
                lst[i] = lst[i + 1];
            // Cấp phát lại vùng nhớ cho lst
            Array.Resize(ref lst, lst.Length - 1);
        }
        // Xuất sv tại vị trí thứ i
        public void OutIndex(int i)
        {
            PrintTitle();
            lst[i].OutputSV();
        }
        // Sắp xếp danh sách với tham số k = 1.theo mã SV, 2.theo tên, 3.theo nghành, 4. Điểm TB
        public void SortList(int k)
        {
            if (k == 1)
            {
                for (int i =0 ; i < lst.Length-1 ; i++)
                    for (int j = i + 1; j < lst.Length; j++)

                        if (string.Compare(lst[i].Maso, lst[j].Maso) > 0)
                            Swap(ref lst[i], ref lst[j]);
            }
            else if (k == 2)
            {
                for (int i = 0; i < lst.Length - 1; i++)
                    for (int j = i + 1; j < lst.Length; j++)
                        if (string.Compare(lst[i].Ten, lst[j].Ten) > 0)
                            Swap(ref lst[i], ref lst[j]);
            }
            else if (k == 3)
            {
                for (int i = 0; i < lst.Length - 1; i++)
                    for (int j = i + 1; j < lst.Length; j++)
                        if (string.Compare(lst[i].Chuyennganh, lst[j].Chuyennganh) > 0)
                            Swap(ref lst[i], ref lst[j]);
            }
            else
            {
                for (int i = 0; i < lst.Length - 1; i++)
                    for (int j = i + 1; j < lst.Length; j++)
                        if (lst[i].DiemTB > lst[j].DiemTB)
                            Swap(ref lst[i], ref lst[j]);
            }
        }
        //Hoán vị 2 phần tử Sinhvien : sx và sy
        public static void Swap(ref Sinhvien sx, ref Sinhvien Sy)
        {
            Sinhvien tmp = new Sinhvien();
            tmp = sx; sx = Sy; Sy = tmp;
        }
        // Ghi danh sách lst vào file DSSV.txt
        public void ListToFile(string filePath)
        {
            //Khởi tạo biến file sw, mở file thông qua biến sw
            StreamWriter sw = new StreamWriter(filePath);
            // Duyệt từng phần tử lst để xây dựng dòng ghi vào file
            for (int i = 0; i < lst.Length; i++)
            {
                // Tạo dòng thông tin của sv và ghi vào file
                string lineSV = lst[i].Maso + '\t' + lst[i].Holot + '\t' + lst[i].Ten + '\t'
                    + lst[i].Ngaysinh + '\t' + lst[i].Phai + '\t' + lst[i].Chuyennganh + '\t'
                    + lst[i].DiemTB;
                sw.WriteLine(lineSV);
            }
            sw.Close(); // Đóng file
        }


    }
}
