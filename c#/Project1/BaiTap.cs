using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class BaiTap
    {
        int Max(int a,int b)
        {
            return a > b ? a : b;
        }
        int Min(int a,int b)
        {
            return a < b ? a : b;
        }
        void Search(int[] a)
        {

        }
        {

        }
        static void Main(string[] args)
        {
            int[] a = new int[4];
            Console.WriteLine("Nhap cac phan tu cho mang");
            for(int i=0;i<4;i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }

        }
    }
}
