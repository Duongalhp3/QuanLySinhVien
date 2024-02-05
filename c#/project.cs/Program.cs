using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.Controllers;
using QuanLySinhVien.Models;
using QuanLySinhVien.Views;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            View view = new View();
            List<Model.Student> StudentList = new List<Model.Student>();
            Controller controller = new Controller();
            do 
            {
                view.ViewProgram();
                do
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            break;
                        case 1:
                            controller.Add(StudentList);
                            break;
                        case 2:
                            controller.Display(StudentList);
                            break;
                        case 3:
                            controller.Sort(StudentList);
                            break;
                        case 4:
                            controller.Delete(StudentList);
                            break;
                        case 5:
                            controller.Update(StudentList);
                            break;
                        case 6:
                            controller.Search(StudentList);
                            break;
                        default:
                            Console.Write("Xin moi nhap lai lua chon: ");
                            break;
                    }
                } while (choice!=0 && choice != 1 && choice != 2 && choice != 3 && choice!=4 && choice!=5 && choice!=6);
            } while (choice!=0);
           
        }
    }  
}