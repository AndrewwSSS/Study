using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12._10._2021.Entities
{
    class Truck : Car
    {
        public Truck()
        {
            
            MinSpeed = new Random().Next(22, 30);
            MaxSpeed = new Random().Next(31, 39);
            NewSpeed();
            OnFinish = () => Console.WriteLine("Ехал долго, но уверенно");
        }
    }
}
