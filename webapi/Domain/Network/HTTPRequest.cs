using System;
using System.Collections.Generic;

namespace webapi.Domain.Network
{
    public class HTTPRequest
    {
        private const int CONTROLLER_PART = 1;
        private const int ID_PART = 2;

        private readonly string[] _parts;
        private HTTPRequest(Verb verb, string url, string body)
        {
            Method = verb;
            URL = url;
            Body = body;
            _parts = this.URL.Split('/');
        }

        public Verb Method { get; private set; }
        public string URL { get; private set; }
        public string Body { get; private set; }
        public static HTTPRequest CreateInstanceByArgs(string[] args)
        {
            var verb = Enum.Parse<Verb>(args[0].ToUpper());
            var uri = args[1];
            if(args.Length == 3)
                return new HTTPRequest(verb, uri, args[2]);

            return new HTTPRequest(verb, uri, "");
        }
        public string GetControllerNameFromRoute() => _parts[CONTROLLER_PART];
        //public string GetParameter() => _parts.Length == 3 ? _parts[ID_PART] : string.Empty;
        public object[] GetParameters()
        {
            var result = new List<object>();

            if (_parts.Length == 3 && int.TryParse(_parts[ID_PART], out int id))
                result.Add(id);

            if (!string.IsNullOrEmpty(Body))
                result.Add(Body);

            return result.ToArray();
        }
    }
}
