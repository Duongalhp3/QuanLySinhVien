using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace QuanLySinhVien.Models
{
    public class Model
    {
        public class Student
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public int ID { get; }
            public float MathScore {get; set; }
            public float PhysicsScore { get; set; }
            public float ChemistryScore { get; set; }
            public float AverageScore { get; set; }
            public string Behavior { get; set; }
            public Student(string Name, string Address, int ID, float MathScore, float PhysicsScore, float ChemistryScore, string Behavior)
            {
                this.Name = Name;
                this.Address = Address;
                this.ID = ID;
                this.MathScore = MathScore;
                this.PhysicsScore = PhysicsScore;
                this.ChemistryScore = ChemistryScore;
                this.AverageScore = (float)(this.MathScore + this.PhysicsScore + this.ChemistryScore) / 3;
                this.Behavior = Behavior;
            }
            public void Display()
            {
                Console.WriteLine(this.Name + " " + this.Address + " " + this.ID + " " + this.MathScore + " " + this.PhysicsScore + " " + this.ChemistryScore + " " + this.AverageScore + " " + this.Behavior);
            }
        }
        public class NameComparer : IComparer<Student>
        {
            public int Compare(Student? x, Student? y)
            {
                string[] xName = x.Name.Split(' ');
                string[] yName = y.Name.Split(' ');
                string xLastName = xName[xName.Length - 1];
                string yLastName = yName[yName.Length - 1];
                int compare = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
                if (compare != 0)
                {
                    return compare;
                }
                else
                {
                    return x.AverageScore.CompareTo(y.AverageScore);
                }
            }
        }
        public class IdComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return x.ID.CompareTo(y.ID);
            }
        }
        public string FormatName(string name)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string formatName = textInfo.ToTitleCase(name);
            formatName = formatName.Trim();
            return formatName;
        }
        public List<Student> SearchName(List<Student> studentList)
        {
            Console.Write("Nhap ten can tim: ");
            string name = Console.ReadLine();
            name = FormatName(name);
            List<Student> searchList = studentList.FindAll(s => name.Contains(s.Name));//dung findall de loc ra danh sach cac ten trung va dung bieu thuc lamda check xem chuoi con co trong chuoi me ko
            if (searchList.Count > 0)
            {
                foreach (Student student in searchList)
                {
                    student.Display();
                } 
                return searchList;
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien!");
                return studentList;
            }
        }
        public void SearchScore(List<Student> studentList,int id)
        {
            if (id == 1)
            {
                float minScore = 8.0f, maxCore = 10.0f;
                List<Student> searchList = studentList.FindAll(s => s.AverageScore >= minScore && s.AverageScore >= maxCore);
                foreach(Student student in searchList)
                {
                    student.Display();
                }
            }
            if(id == 2)
            {
                float minScore = 5.0f, maxCore = 8.0f;
                List<Student> searchList = studentList.FindAll(s => s.AverageScore >= minScore && s.AverageScore > maxCore);
                foreach (Student student in searchList)
                {
                    student.Display();
                }
            }
            if (id == 3)
            {
                float minScore = 0.0f, maxCore = 5.0f;
                List<Student> searchList = studentList.FindAll(s => s.AverageScore >= minScore && s.AverageScore > maxCore);
                foreach (Student student in searchList)
                {
                    student.Display();
                }
            }
        }
        public void Delete(List<Student> studentList,List<Student> searchList,int id)
        {
            if (id == 1)
            {
                Console.Write("Nhap id muon xoa: ");
                int code = int.Parse(Console.ReadLine());
                studentList.RemoveAll(s => s.ID == code);
            }
            if (id == 2)
            {
                if(searchList.Count > 0) 
                {
                    foreach (Student student in searchList)
                    {
                        studentList.RemoveAll(s => s.ID == student.ID);
                    }
                }
            }         
        }
    }
}

