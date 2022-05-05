using System;
using System.Diagnostics;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(@"C:\");
           

            manager.ReadAllTxtFiles();
     
        }
    }
}
