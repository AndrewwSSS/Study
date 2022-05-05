using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
                return;
            Console.WriteLine($"Arguments: {args[0]} {args[1]} {args[2]}");

            try
            {

                switch (args[1])
                {
                    case "-":
                        Console.WriteLine("Result: " + (int.Parse(args[0]) - int.Parse(args[2])).ToString());
                        break;

                    case "+":
                        Console.WriteLine("Result: " + (int.Parse(args[0]) + int.Parse(args[2])).ToString());
                        break;

                    case "/":
                        Console.WriteLine("Result: " + (int.Parse(args[0]) / int.Parse(args[2])).ToString());
                        break;

                    case "*":
                        Console.WriteLine("Result: " + (int.Parse(args[0]) * int.Parse(args[2])).ToString());
                        break;
                }

                Console.ReadKey();
            }catch (Exception) { }
        

            




        }
    }
}
