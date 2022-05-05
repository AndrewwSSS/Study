using System;
using ParseExeptions.DBcontext;
namespace ParseExeptions
{
    class Program
    {
        static void Main(string[] args)
        {
            DBContext DB = new DBContext();
            DB.ReadFromFile();
            DB.SaveAsStatistic(@".\result.csv");
        }
    }
}
