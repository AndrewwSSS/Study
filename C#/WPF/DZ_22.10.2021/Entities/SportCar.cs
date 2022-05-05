using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12._10._2021.Entities
{
    class SportCar : Car
    {
        public SportCar()
        {
            

            MinSpeed = new Random().Next(100, 150);
            MaxSpeed = new Random().Next(155, 200);
            NewSpeed();
            OnFinish = () => Console.WriteLine($"Я приехал и у меня перегрелся двигатель(((");
        }
    }
}
