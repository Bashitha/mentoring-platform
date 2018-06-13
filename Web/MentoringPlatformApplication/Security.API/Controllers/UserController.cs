using Mapster;
using Microsoft.AspNetCore.Mvc;
using Security.API.Models;
using Security.Domain.Entities;
using Security.Domain.IRepositories;
using System.Collections.Generic;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            
            return null;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public User Post([FromBody]UserViewModel userViewModel)
        {
            
            var user = _userRepository.Add(userViewModel.Adapt<User>());

            return user;

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
