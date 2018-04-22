using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Security.API.Models;


namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/UserRole")]
    public class UserRoleController : Controller
    {
        // GET: api/UserRole
        [HttpGet]
        public IEnumerable<UserRole> Get()
        {
            var list = new List<UserRole>();
            list.Add(new UserRole() {UserRoleId = 1, UserRoleName = "Admin"});
            list.Add(new UserRole() { UserRoleId = 2, UserRoleName = "Mentor" });
            list.Add(new UserRole() { UserRoleId = 3, UserRoleName = "Mentee" });
            return list;
        }

        // GET: api/UserRole/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/UserRole
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/UserRole/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
