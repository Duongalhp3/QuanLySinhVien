using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Views;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class Controller
    {
        private View view = new View();
        private Model model = new Model();
        //method add
        public void Add(List<Model.Student> StudentList)
        {
            string name, address, behavior;
            float math, physics, chemistry;
            int id;
            Console.Write("Nhap so luong sinh vien muon them: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Nhap thong tin cho sinh vien thu " + i);
                view.ViewAdd(out name,out address,out id,out math,out physics,out chemistry,out behavior);
                StudentList.Add(new Model.Student(name, address, id, math, physics, chemistry, behavior));
            }
            Console.WriteLine("Them thanh cong");
        }
        //method display
        public void Display(List<Model.Student> StudentList)
        {
            foreach (Model.Student student in StudentList)
            {
                student.Display();
            }
        }
        //method delete
        public void Delete(List<Model.Student> StudentList)
        {
            int choice;
            do 
            {
                List<Model.Student> searchList = model.SearchName(StudentList);
                view.ViewDelete();
                do 
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            break;
                        case 1:
                            model.Delete(StudentList,searchList, 1);
                            break; 
                        case 2:
                            model.Delete(StudentList,searchList, 2);
                            break;
                        default:
                            Console.Write("Xin moi nhap lai lua chon: ");
                            break;
                    }
                } while(choice != 0 && choice!=1 && choice!=2);
            } while (choice != 0 && choice != 1 && choice != 2);
        }
        //method sort
        public void Sort(List<Model.Student> StudentList)
        {
            StudentList.Sort(new Model.NameComparer());
            Console.WriteLine("Danh sach da duoc sap xep");
        }
        //method update
        public void Update(List<Model.Student> StudentList)
        {
            int choice,index;
            view.ViewUpdate(1);
            do 
            {
                int id = int.Parse(Console.ReadLine());
                if (StudentList.Count > 1)
                {
                    StudentList.Sort((x, y) => x.ID.CompareTo(y.ID));//sap xep lai id de tim kiem nhi phan
                }
                index = StudentList.BinarySearch(new Model.Student("", "", id, 0, 0, 0, ""), new Model.IdComparer());
                if (index < 0)
                {
                    view.ViewUpdate(3);
                }
                else
                {
                    view.ViewUpdate(2);
                    do
                    {
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 0:
                                break;
                            case 1:
                                Console.Write("Nhap ten moi: ");
                                StudentList[index].Name = Console.ReadLine();
                                StudentList[index].Name = model.FormatName(StudentList[index].Name);
                                Console.WriteLine("Sua thanh cong");
                                break;
                            case 2:
                                Console.Write("Nhap dia chi moi: ");
                                StudentList[index].Address = Console.ReadLine();
                                StudentList[index].Address= model.FormatName(StudentList[index].Address); Console.WriteLine("Sua thanh cong");
                                break;
                            case 3:
                                Console.Write("Nhap diem toan moi: ");
                                StudentList[index].MathScore=float.Parse(Console.ReadLine());
                                StudentList[index].AverageScore = (float)(StudentList[index].MathScore + StudentList[index].PhysicsScore + StudentList[index].ChemistryScore)/ 3;
                                Console.WriteLine("Sua thanh cong");
                                break;
                            case 4:
                                Console.Write("Nhap diem ly moi: ");
                                StudentList[index].PhysicsScore = float.Parse(Console.ReadLine());
                                StudentList[index].AverageScore = (float)(StudentList[index].MathScore + StudentList[index].PhysicsScore + StudentList[index].ChemistryScore) / 3;
                                Console.WriteLine("Sua thanh cong");
                                break;
                            case 5:
                                Console.Write("Nhap diem hoa moi: ");
                                StudentList[index].ChemistryScore = float.Parse(Console.ReadLine());
                                StudentList[index].AverageScore = (float)(StudentList[index].MathScore + StudentList[index].PhysicsScore + StudentList[index].ChemistryScore) / 3;
                                Console.WriteLine("Sua thanh cong");
                                break;
                            case 6:
                                Console.WriteLine("Chon hanh kiem moi");
                                Console.WriteLine("1.Tot");
                                Console.WriteLine("2.Kha");
                                Console.WriteLine("3.Yeu");
                                Console.WriteLine("------------------------");
                                Console.Write("Nhap lua chon: ");
                                do
                                {
                                    choice = int.Parse(Console.ReadLine());
                                    switch (choice)
                                    {
                                        case 1:
                                            StudentList[index].Behavior = "Tot";
                                            break;
                                        case 2:
                                            StudentList[index].Behavior = "Kha";
                                            break;
                                        case 3:
                                            StudentList[index].Behavior = "Yeu";
                                            break;
                                        default:
                                            Console.Write("Xin moi nhap lai lua chon");
                                            break;
                                    }
                                } while (choice != 1 && choice != 2 && choice != 3);
                                Console.WriteLine("Sua thanh cong");
                                break;
                            default:
                                Console.Write("Xin moi nhap lai lua chon cua ban: ");
                                break;
                        }
                    } while (choice != 0 && choice != 1 && choice != 2 && choice != 3);
                }
            } while(index<0);
        }
        //method search
        public void Search(List<Model.Student> StudentList)
        {
            int choice;
            view.ViewSearch(1);
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        model.SearchName(StudentList);
                        break;
                    case 2:
                        view.ViewSearch(2);
                        do 
                        {
                            choice =int.Parse(Console.ReadLine());
                            switch (choice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    model.SearchScore(StudentList, 1);
                                    break;
                                case 2:
                                    model.SearchScore(StudentList, 2);
                                    break;
                                case 3:
                                    model.SearchScore(StudentList, 3);
                                    break;
                                default:
                                    Console.WriteLine("Xin moi nhap lai lua chon: ");
                                    break;
                            }
                        } while (choice != 0 && choice!=1 && choice!=2 && choice!=3);
                        break;
                    default:
                        Console.WriteLine("Xin moi nhap lai lua chon: ");
                        break;
                }
            } while (choice != 0 && choice != 1 && choice != 2 && choice != 3);
        }
    }
}
