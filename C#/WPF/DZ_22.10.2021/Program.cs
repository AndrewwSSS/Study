using System;

namespace DZ_12._10._2021
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext neContext = new DBContext();
            neContext.Start();
            Console.ReadKey();
        }
    }
}
