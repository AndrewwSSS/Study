using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12._10._2021.Entities
{
    class PassengerСar : Car
    {
        public PassengerСar() {
            
            MinSpeed = new Random().Next(40, 60);
            MaxSpeed = new Random().Next(62, 80);
            NewSpeed();
            OnFinish = () => Console.WriteLine($"Я приехал мое имя - {Name}");
        }
    }
}
