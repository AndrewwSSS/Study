using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace UsageLegacyCode1
{
    internal class Program
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("User32.dll", ExactSpelling = true)]
        private static extern bool MessageBeep(uint type);


        public enum beepType
        {
            SimpleBeep = -1,
            OK = 0x00,
            Question = 0x20,
            Exclamation = 0x30,
            Asterisk = 0x40
        }

        static void Main(string[] args)
        {
            //Task1();
            Task2();
            //Task3();
            Console.ReadKey();
        }


        public static void Task1()
        {
            MessageBox(IntPtr.Zero, "Hallo. My name is Andreww", "My name", 0);
            MessageBox(IntPtr.Zero, "I'm from Ukraine", "", 0);
        }


        public static void Task2()
        {
            IntPtr hwd = FindWindowByCaption(IntPtr.Zero, "Viber");
            StringBuilder stringBuilder = new StringBuilder();

            if (hwd != IntPtr.Zero)
            {
                Console.WriteLine("Enter string to replace(Empty string is default)...");

                string NewCaption = Console.ReadLine();

                if(NewCaption == "")
                {
                    NewCaption = "Default1";
                }

                stringBuilder.Append(NewCaption);

       
                SendMessage(hwd, 0x000C, 0, stringBuilder);
            }
        }

        public static void Task3()
        {
            MessageBeep((uint)beepType.OK);
            Thread.Sleep(1000);
            MessageBeep((uint)beepType.Question);
            Thread.Sleep(1000);
            MessageBeep((uint)beepType.Asterisk);
            Thread.Sleep(1000);
            MessageBeep((uint)beepType.Exclamation);

        }


        public static void Task4()
        {
            // I don't know what functions use
        }

    }
}
