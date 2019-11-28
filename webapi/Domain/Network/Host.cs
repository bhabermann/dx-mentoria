using System;
using System.Linq;
using System.Reflection;

namespace webapi.Domain.Network
{
    public class Host
    {
        public static object Execute(HTTPRequest request)
        {
            var controllerType = GetInstanceTypeByRequest(request);

            if (controllerType == null)
                throw new Exception("There is no controller for the informed route");

            var returnValue = ExecuteMethod(request, controllerType);

            return returnValue;
        }

        private static object ExecuteMethod(HTTPRequest request, Type controllerType)
        {
            var instance = Activator.CreateInstance(controllerType);
            var methods = instance.GetType().GetMethods().Where(x => x.Name == request.Method.ToPascalCase()).ToArray();
            var paramArray = request.GetParameters();
            var returnValue = methods.FirstOrDefault(x => x.GetParameters().Count() == paramArray.Count()).Invoke(instance, paramArray);
            return returnValue;
        }

        private static Type GetInstanceTypeByRequest(HTTPRequest request)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().ToList().FirstOrDefault(x => x.Name == request.GetControllerNameFromRoute() && x.Namespace.Contains("Controllers"));

            return type;
        }
        
    }
}
