using System;

namespace ParseNewPost
{
    class Program
    {
        static void Main(string[] args)
        {
            Data.DbContext dbContext = new Data.DbContext();
            dbContext.Run();

            Console.ReadKey();
        }
    }
}
