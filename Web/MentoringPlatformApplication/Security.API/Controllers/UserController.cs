using Microsoft.AspNetCore.Mvc;
using Security.API.Models;
using System.Collections.Generic;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        List<User> list = new List<User>();
        
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            list.Add(new User() { UserId = 1, Email = "lbw@tiqri.com", Password = "abc", FirstName = "Leshan", LastName = "Wijegunawardana", Description = ".Net", Designation = "SE", UserRoleId = 3 });
            list.Add(new User() { UserId = 2, Email = "dtm@tiqri.com", Password = "abc", FirstName = "Dhanika", LastName = "Munasinghe", Description = ".Net", Designation = "SE", UserRoleId = 3 });
            list.Add(new User() { UserId = 3, Email = "mvn@tiqri.com", Password = "abc", FirstName = "Mark", LastName = "Sinnathamby", Description = ".Net", Designation = "TL", UserRoleId = 1 });

            return list;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public User Post([FromBody]User user)
        {
            list.Add(user);
            return list[list.Count-1];

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
