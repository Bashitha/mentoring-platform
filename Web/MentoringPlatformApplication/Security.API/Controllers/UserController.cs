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
        public List<UserViewModel> Get()
        {
            var users = _userRepository.ListAll();

            if (users == null)
                return null;

            return users.Adapt<List<UserViewModel>>();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return null;

            return user.Adapt<UserViewModel>();
            
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
        public ActionResult Put(int id, [FromBody]UserViewModel userViewModel)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            _userRepository.Update(user);
            return Ok();

        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
