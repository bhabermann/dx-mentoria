using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Domain.Business;

namespace webapi.Repository
{
    public class UserRepository : BaseRepository<User>
    {

        private static IList<User> users = new List<User>();

        public UserRepository() : base(users) {}
        
    }
}
