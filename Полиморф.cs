using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsolePrPolymorf
{
    class Volume
    {
        public double V { get; set; }
        public string Name { get; set; }
        public virtual void Raschet()
        {
            Console.WriteLine(Name + "  -  " + V);
        }
        class Cube : Volume
        {
            public double a;
            public override void Raschet()
            {
                V = a * a * a;
                Console.WriteLine(Name + "-" + V);
            }

        }
        class ParralelP : Volume
        {
            public double a;
            public double b;
            public double c;
            public override void Raschet()
            {
                V = a * b * c;
                Console.WriteLine(Name + "-" + V);
            }

        }
        class Tsilindr : Volume
        {
            public double p = 3.14;
            public double r;
            public double h;
            public override void Raschet()
            {
                V = p * r * r * h;
                Console.WriteLine(Name + "-" + V);
            }
        }
        class Shar : Volume
        {
            public double p = 3.14;
            public double r;
            public double v;
            public override void Raschet()
            {
                v = 4 * p * r * r * r;
                V = v / 3;
                Console.WriteLine(Name + "-" + V);

            }
        }
        class Полиморф
        {

            static void Main(string[] args)
            {
                Cube ChetCube = new Cube { Name = "Куб", a = 4 };
                ChetCube.Raschet();
                ParralelP ChetParra = new ParralelP { Name = "Парралелепипед", a = 5, b = 7, c = 8 };
                Tsilindr ChetTsilindr = new Tsilindr { Name = "Цилиндр", r = 5, h = 4 };
                ChetParra.Raschet();
                Shar ChetShar = new Shar { Name = "Шар", r = 5, v = 7 };
                ChetShar.Raschet();
            }
        }
    }
}
