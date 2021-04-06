using System;

namespace LoggerAsync
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Starter starter = new ();
            starter.Run();
            Console.ReadKey();
        }
    }
}
