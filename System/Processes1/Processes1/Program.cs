using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Management;
using System.Threading;

namespace Processes1
{
    internal class Program
    {



        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
            Console.ReadKey();
        }

        public static void Task1()
        {
            Process proc = Process.Start("notepad.exe");
            proc.EnableRaisingEvents = true;
            proc.Exited += onProcExited;
            proc.WaitForExit();
        }


        public static void Task2()
        {
            Process proc = Process.Start("notepad.exe");
            proc.EnableRaisingEvents = true;
            proc.Exited += onProcExited;

            Console.WriteLine("Kill proccess - 0, Wait for exit - 1");
            string res = Console.ReadLine();

            if(res == "0")
            {
                proc.Kill();
            }

            proc.WaitForExit();


        }

        public static void Task3()
        {
            Process proc = Process.Start("calc.exe", "7 * 7");

        }

        public static void Task4()
        {
            Process proc = Process.Start("CountEntryStringInFile.exe", @".\test.txt c#");

        }

        public static void onProcExited(object sender, EventArgs e)
        {
            Console.WriteLine($"Exit code: {(sender as Process).ExitCode}");

        }


        public static int GetParentProcessId(int Id)
        {
            int parentId = 0;
            using (ManagementObject obj = new ManagementObject("win32_process.handle=" + Id.ToString()))
            {
                obj.Get();
                parentId = Convert.ToInt32(obj["ParentProcessId"]);
            }
            return parentId;
        }
    }
}
