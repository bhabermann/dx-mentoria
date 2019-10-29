using System;
using System.Linq;
using System.Reflection;
using webapi.Domain;

namespace webapi
{
    class Program
    {
        static void Main(string[] args)
        {

            var httpRequest = HTTPRequest.CreateInstanceByArgs(args);
            var httpResponse = Host.Execute(httpRequest);

            Console.WriteLine(httpResponse);


            Console.ReadKey();
        }
    }
}
