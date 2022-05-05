using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_12._10._2021.Entities;

namespace DZ_12._10._2021
{
    class DBContext
    {
        public List<Car> CarsStart = new List<Car>();
        public List<Car> CarsFinished = new List<Car>();
        public int Distance;

        public void Start()
        {
            CarsStart.Clear();
            Distance = new Random().Next(100, 200);

            //switch (new Random().Next(1, 4))
            //{
            //    case 1:
            //        for (int i = 0; i < 5; i++)
            //            CarsStart.Add(new Bus());
            //        break;
            //    case 2:
            //        for (int i = 0; i < 5; i++)
            //            CarsStart.Add(new PassengerСar());
            //        break;
            //    case 3:
            //        for (int i = 0; i < 5; i++)
            //            CarsStart.Add(new SportCar());
            //        break;
            //    case 4:
            //        for (int i = 0; i < 5; i++)
            //            CarsStart.Add(new Truck());
            //        break;
            //}

            CarsStart.Add(new PassengerСar() { Name = "Aбоба"     });
            CarsStart.Add(new PassengerСar() { Name = "Александр" }); 
            CarsStart.Add(new PassengerСar() { Name = "Петр"      });
            CarsStart.Add(new PassengerСar() { Name = "Денис"     });
            bool WinnerExist = false;

            while (CarsStart.Count != 0)
            {
                foreach (var car in CarsStart)
                {
                    car.Drive();
                    if(car.DistanceTraveled >= Distance)
                    {
                        if (WinnerExist == false)
                        {
                            Console.WriteLine($"Победитель - {car.Name}");
                            car.OnFinish();
                            WinnerExist = true;
                        }
                        else {
                            Console.WriteLine($"Приехала машина {car.Name}");
                            car.OnFinish();
                        }
                        CarsFinished.Add(car);
                    }
                }

                foreach (var car in CarsFinished)
                    CarsStart.Remove(car);
            }

        }

    }
}
