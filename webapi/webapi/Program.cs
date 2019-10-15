using System;
using System.Linq;

namespace webapi
{
    class Program
    {
        static void Main(string[] args)
        {
            args.ToList().ForEach(arg => Console.WriteLine(arg));

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
