using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace buoi1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = Encoding.Unicode;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.Unicode;

            /* Tạo menu */
            Menu menu = new Menu();
            // Xây dựng giá trị cho các tham số để gọi phương thức ShowMenu(title, ms)
            string title = "QUẢN LÝ HỒ SƠ SINH VIÊN";   // Tiêu đề menu
            // Danh sách các mục chọn
            string[] ms = { "1. Xem danh sách sinh viên", "2. Thêm sinh viên mới",
                "3. Tìm kiếm", "4. Cập nhật Điểm TB", "5. Xóa sinh viên",
                "6. Cập nhật danh sách vào file", "0. Thoát" };

            DSSV ds = new DSSV();
            // Tạo đường dẫn file dùng làm tham số
            string filePath = "../../../TextFile/DSSV.txt";
            ds.FileToList(filePath);    // Đọc file -> ds
            int chon;
            do
            {
                // Xuất menu
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            ViewDSSV(ds); break;
                        }
                    case 2:
                        {
                            ds.AddNewSV();
                            break;
                        }
                    case 3:
                        {
                            Console.Write(" Nhập mã sinh viên cần tìm : ");
                            string ma = Console.ReadLine();
                            int vitri = ds.FindSV(ma);
                            if (vitri == -1)
                                Console.WriteLine("   Không có sinh viên này");
                            else
                            {
                                ds.PrintTitle();
                                ds.Lst[vitri].OutputSV();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write(" Nhập mã sinh viên cần sửa điểm : ");
                            string ma = Console.ReadLine();
                            int vt = ds.FindSV(ma);
                            if (vt == -1)
                                Console.WriteLine("   Không có sinh viên này");
                            else
                            {
                                ds.PrintTitle();
                                ds.Lst[vt].OutputSV();
                                Console.Write(" Điểm cập nhật : ");
                                float d = float.Parse(Console.ReadLine());
                                ds.Lst[vt].DiemTB = d;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write(" Nhập mã sinh viên cần xóa : ");
                            string ma = Console.ReadLine();
                            int vt = ds.FindSV(ma);
                            if (vt == -1)
                                Console.WriteLine("   Không có sinh viên này");
                            else
                            {
                                ds.PrintTitle();
                                ds.Lst[vt].OutputSV();
                                Console.Write(" Có chắc xóa sinh viên trên (0/1?) : ");
                                int ch = int.Parse(Console.ReadLine());
                                if (ch == 1)
                                    ds.DeleteSV(vt);
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Write(" Có muốn cập nhật ds vào file (0/1?) : ");
                            int ch = int.Parse(Console.ReadLine());
                            if (ch == 1)
                                ds.ListToFile(filePath);
                            break;
                        }
                }
                Console.WriteLine(" Nhấn một phím bất kỳ");
                Console.ReadKey();
                Console.Clear();
            } while (chon != 0);
        }
        static void ViewDSSV(DSSV ds)
        {
            Console.WriteLine("Chọn cách thức xem danh sách :");
            Console.WriteLine("  1. Sắp xếp theo Mã sinh viên.");
            Console.WriteLine("  2. Sắp xếp theo Tên.");
            Console.WriteLine("  3. Sắp xếp theo Chuyên nghành");
            Console.WriteLine("  4. Sắp xếp theo Điểm TB.");
            Console.Write("       Chọn : ");
            int chon = int.Parse(Console.ReadLine());
            // Sắp xếp danh sách theo tiêu chuẩn chon
            ds.SortList(chon);
            ds.PrintDSSV();
        }
    }

}
                

