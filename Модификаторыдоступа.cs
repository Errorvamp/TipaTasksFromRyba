using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    class Car
    {
        private string make;//что бы просто так нельзя было поменять как вздумается типа
        private string model;
        public int Year { get; set; }//чтоб без раритетов всяких


        internal void SetMakeAndModel(string make, string model)
        {
            this.make = make;
            this.model = model;
        }

        protected void DisplayInfo(string make, string model) => Console.WriteLine(make, model);//а зачем... его жн вывести вообще не получается из за протектеда
    }

    class ElectricCar : Car
    {
        private double batteryCapacity;//для привязки к проекту ее наверное

        public void SetBatteryCapacity(double batteryCapacity)
        {
            this.batteryCapacity = batteryCapacity;
        }
        protected void DisplayInfo(string make, string model) => Console.WriteLine(make, model);//понятия не имею....
    }
    internal class Модификаторыдоступа
    {
        
        static void Main(string[] args)
        {
            Car car = new Car();
            car.make = "fff";
            car.model = "dfsf";
            car.SetMakeAndModel("germany","volswagen");
            ElectricCar electricCar = new ElectricCar();
            electricCar.SetBatteryCapacity(18472);
            car.DisplayInfo();
            electricCar.DisplayInfo();
        }
    }
}
