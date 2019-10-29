using System;
using System.Linq;
using System.Reflection;

namespace webapi
{
    class Program
    {
        static void Main(string[] args)
        {

            // First arg = Verb (Get, Post, Put, Delete)
            // Second arg = endpoint (Eg.: Users/1)
            // Third arg = data json

            //get / Users / 1 = UserController->Get(parameter) => list.where(id => parameter).First();
            //post / Users = UserController->Post(user) => list.Add(user);
            //get / Users = UserController->Post(user) => list.ToList();
            //payload: { }

            //get / Products / 1 = UserController->Get(parameter) => list.where(id => parameter).First();
            //post / Products = UserController->Post(user) => list.Add(user);
            //get / Products = UserController->Post(user) => list.ToList();
            //payload: { }

            args = "Put User/1 '{User:UserInfo}'".Split(" ");

            if ((args.Count() < 2) || (args.Count() > 3))
            {
                Console.WriteLine("Program expects at least two or three arguments");
                return;
            }

            var verb = args[0];
            var route = args[1];
            var data = string.Empty;
            if (args.Count() == 3)
                data = args[2];

            var splitRoute = route.Split("/");

            Console.WriteLine($"Verbo: {verb}");
            Console.WriteLine($"Rota: {route}");
            Console.WriteLine($"Dados: {data}");

            string controllerName = $"{splitRoute[0]}Controller";

            object[] parameters = Array.Empty<object>();
            if (splitRoute.Count() > 1)
                parameters = splitRoute.Skip(1).ToArray();

            parameters.Append(data);

            var result = Caller(controllerName, verb, parameters);

            Console.WriteLine(result);

            Console.ReadKey();
        }

        static object Caller(string myclass, string mymethod, object[] parameters)
        {

            Assembly assem = typeof(Program).Assembly;
            // Get a type from the string 
            Type type = assem.GetType($"webapi.{myclass}", true, true);
            // Create an instance of that type
            object obj = Activator.CreateInstance(type);
            // Retrieve the method you are looking for
            MethodInfo methodInfo = type.GetMethod(mymethod);
            // Invoke the method on the instance we created above
            return methodInfo.Invoke(obj, parameters);

        }
    }
}
