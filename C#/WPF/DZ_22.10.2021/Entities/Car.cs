using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12._10._2021
{
    abstract class Car
    {
        public int DistanceTraveled = 0;
        public Car() {
            NewSpeed = () => CurrSpeed = new Random().Next(MinSpeed, MaxSpeed);
           
        }
        public Action OnFinish;
        public Action NewSpeed;
        public string Name { get; set; }

        // Скорость км в час
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrSpeed { get; set; }

        public void Drive() {
            // За одну минуту в метрах
            DistanceTraveled += (CurrSpeed / 60) * 1000;
            NewSpeed();
        }

    }
}
