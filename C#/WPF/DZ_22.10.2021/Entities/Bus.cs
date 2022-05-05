using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_12._10._2021.Entities
{
    class Bus : Car
    {
        public Bus()
        {
          

            MinSpeed = new Random().Next(15, 20);
            MaxSpeed = new Random().Next(25, 30);
            NewSpeed();
            OnFinish = () => Console.WriteLine("Везу много пасажиров, ехал медленно");
        }
    }
}
