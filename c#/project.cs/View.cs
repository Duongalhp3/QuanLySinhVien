using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Views
{
    public class View
    {
        private Model model=new Model();
        public void ViewAdd(out string name, out string address, out int id, out float math, out float physics, out float chemistry, out string behavior)
        {
            int choice;
            behavior = "";
            Console.Write("Nhap ten: ");
            name = Console.ReadLine();
            name = model.FormatName(name);
            Console.Write("Nhap dia chi: ");
            address = Console.ReadLine();
            address = model.FormatName(address);
            Console.Write("Nhap ma: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Nhap diem toan: ");
            math = float.Parse(Console.ReadLine());
            Console.Write("Nhap diem ly: ");
            physics = float.Parse(Console.ReadLine());
            Console.Write("Nhap diem hoa: ");
            chemistry = float.Parse(Console.ReadLine());
            Console.WriteLine("Chon hanh kiem");
            Console.WriteLine("1.Tot");
            Console.WriteLine("2.Kha");
            Console.WriteLine("3.Yeu");
            Console.WriteLine("-------------------------------");
            Console.Write("Nhap lua chon cua ban: ");
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        behavior = "Tot";
                        break;
                    case 2:
                        behavior = "Kha";
                        break;
                    case 3:
                        behavior = "Yeu";
                        break;
                    default:
                        Console.Write("Xin moi nhap lai lua chon: ");
                        break;
                }
            } while (choice !=1 && choice!=2);
        }
        public void ViewUpdate(int id)
        {
            if (id == 1)
            {
                Console.Write("Nhap id sinh vien muon sua: ");
            }
            if (id == 2)
            {
                Console.WriteLine("1.Sua ten");
                Console.WriteLine("2.Sua dia chi");
                Console.WriteLine("3.Sua diem toan");
                Console.WriteLine("4.Sua diem ly");
                Console.WriteLine("5.Sua diem hoa");
                Console.WriteLine("6.Sua hanh kiem");
                Console.WriteLine("0.Thoat");
                Console.WriteLine("-----------------------------");
                Console.Write("Nhap lua chon cua ban: ");
            }
            if (id == 3)
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                Console.WriteLine("Xin moi nhap lai id: ");
            }

        }
        public void ViewSearch(int id)
        {
            if (id == 1)
            {
                Console.WriteLine("1.Tim kiem theo ten");
                Console.WriteLine("2.Tim kiem theo diem trung binh");
                Console.WriteLine("0.Thoat");
                Console.WriteLine("------------------------------------");
                Console.Write("Nhap lua chon cua ban: ");
            }
            if (id == 2)
            {
                Console.WriteLine("1.Tu 8 den 10");
                Console.WriteLine("2.Tu 5 den 8");
                Console.WriteLine("3.Duoi 5");
                Console.WriteLine("0.Thoat");
                Console.WriteLine("------------------------------");
                Console.Write("Nhap lua chon cua ban: ");
            }
        }
        public void ViewDelete()
        {
            Console.WriteLine("1.Xoa 1 nguoi");
            Console.WriteLine("2.Xoa toan bo");
            Console.WriteLine("0.Thoat");
            Console.WriteLine("-------------------------");
            Console.Write("Nhap lua chon cua ban: ");
        }
        public void ViewProgram()
        {
            Console.WriteLine("       He Thong Quan Ly Sinh Vien");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1.Them");
            Console.WriteLine("2.Hien Thi");
            Console.WriteLine("3.Sap Xep");
            Console.WriteLine("4.Xoa");
            Console.WriteLine("5.Cap Nhat Thong Tin");
            Console.WriteLine("6.Tim Kiem");
            Console.WriteLine("0.Thoat");
            Console.WriteLine("----------------------------------------");
            Console.Write("Nhap lua chon cua ban: ");
        }
    }
}
