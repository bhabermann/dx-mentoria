using System;
using System.Collections.Generic;
using System.Text;

namespace webapi
{
    public class UserController
    {
        public string Get(string id)
        {
            return $"Getting user number of ID '{id}'";
        }

        public string Get()
        {
            return $"Getting all users";
        }

        public string Post(string data)
        {
            return $"Creating User from '{data}'";
        }

        public string Put(string id, string data)
        {
            return $"Updating User of ID '{id}' with '{data}'";
        }

        public string Delete(string id)
        {
            return $"Deleting User of ID '{id}'";
        }
    }
}
