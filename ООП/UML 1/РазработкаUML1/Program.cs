using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РазработкаUML1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Население страны равно M млн чел., количество врачей – B млн чел.
            //Прогнозируется ежегодный рост населения на р % и ежегодное увеличение 
            //числа врачей на Q тыс. специалистов. Найти количество врачей на 
            //100 тыс. чел населения для каждого из ближайших десяти лет
            int M = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int Q = int.Parse(Console.ReadLine());
            int futurepp = M * p / 100;
            int doconp = (futurepp / (B * Q)) / 100000;
            Console.WriteLine(doconp);
        }
    }
}
