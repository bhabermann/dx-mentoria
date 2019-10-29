using System;
using System.Collections.Generic;
using System.Text;

namespace webapi.Domain
{
    public class HTTPRequest
    {
        private readonly string[] _parts;
        private HTTPRequest(Verb verb, string uRL, string body)
        {
            Method = verb;
            URL = uRL;
            Body = body;
            _parts = URL.Split('/');
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
        public string GetControllerNameFromRoute()
            => _parts[1];
        public string GetParameter()
            => _parts[2];


    }
}
