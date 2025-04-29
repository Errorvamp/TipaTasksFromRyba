using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePeregrMetodov
{
    class Volume
    {
        public double p = 3.14;
        public void Raschet(double a)
        {
            double V;
            V = a * a * a;
            Console.WriteLine("Объем куба:" + V);
        }
        public void Raschet(double a, double b, double c)
        {
            double V;
            V = a * b * c;
            Console.WriteLine("Объем прямоугольного параллелепипеда:" + V);
        }
        public void Raschet(double r, double h)
        {
            double V;
            V = p * r * r * h;
            Console.WriteLine("Объем цилиндра:" + V);
        }
        public void Raschet(double r,double v,string name)
        {
            double V;
            v = 4 * p * r * r * r;
            V = v / 3;
            name = "шара";
            Console.WriteLine("Объем" + name + ":" + V);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Volume volume = new Volume();
            volume.Raschet(4);
            volume.Raschet(3,4,5);
            volume.Raschet(4,5);
            volume.Raschet(2,0,".");

        }
    }
}