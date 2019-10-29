using System;
using System.Collections.Generic;
using System.Text;

namespace webapi.Domain
{
    public static class Helper
    {
        public static string ToPascalCase(this Verb verb)
        {
            var value = verb.ToString();
            var begin = value[0].ToString().ToUpper();
            var end = value.Substring(1, value.Length - 1).ToLower();

            return begin + end;

        }

    }
}
