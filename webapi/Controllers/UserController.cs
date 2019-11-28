using Newtonsoft.Json;
using webapi.Domain.Business;
using webapi.Repository;

namespace webapi.Controllers
{
    public class UserController
    {
        private UserRepository userRepository = new UserRepository(); 


        public string Get(int id)
        {
            var user = userRepository.Get(x => x.Id == id);
            var json = JsonConvert.SerializeObject(user);
            return json;
        }

        public string Get()
        {
            var user = userRepository.Get();
            var json = JsonConvert.SerializeObject(user);
            return json;
        }

        public string Post(string data)
        {
            var user = JsonConvert.DeserializeObject<User>(data);
            userRepository.Insert(user);
            var json = JsonConvert.SerializeObject(user);
            return json;
        }

        public string Put(int id, string data)
        {
            var user = JsonConvert.DeserializeObject<User>(data);
            userRepository.Update(x => x.Id == id, user);
            var json = JsonConvert.SerializeObject(user);
            return json;
        }

        public string Delete(int id)
        {
            userRepository.Delete(x => x.Id == id);
            return $"User deleted";
        }
    }
}
