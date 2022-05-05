using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Count_entry_string_in_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 2)
            {
                if (File.Exists(args[0]) && (Path.GetExtension(args[0]) == ".txt"))
                {
                    if(!string.IsNullOrWhiteSpace(args[1]))
                    {
                        using (StreamReader sr = new StreamReader(args[0]))
                        {
                            string line = sr.ReadToEnd();
                            int countEntrys = Regex.Matches(line, args[1]).Cast<Match>().Count();
                            Console.WriteLine("Result: " + countEntrys);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid 2 argument");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid path or type of file");
                }
            }
            Console.ReadKey();
        }
    }
}
