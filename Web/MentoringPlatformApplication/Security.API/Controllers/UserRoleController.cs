using System.Collections.Generic;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Security.API.Models;
using Security.Domain.Entities;
using Security.Domain.IRepositories;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/UserRole")]
    public class UserRoleController : Controller
    {
        private readonly IRepository<UserRole> _userRoleRepository;

        public UserRoleController(IRepository<UserRole> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }



        // GET: api/UserRole
        [HttpGet]
        public IEnumerable<UserRoleViewModel> Get()
        {
            var userRoles = _userRoleRepository.ListAll();

            return userRoles.Adapt<List<UserRoleViewModel>>();
        }

        // GET: api/UserRole/5
        [HttpGet("{id}")]
        public UserRoleViewModel Get(int id)
        {
            return _userRoleRepository.GetById(id).Adapt<UserRoleViewModel>();
        }
        
        // POST: api/UserRole
        [HttpPost]
        public UserRole Post([FromBody]UserRoleViewModel userRoleViewModel)
        {
            var userRole = _userRoleRepository.Add(userRoleViewModel.Adapt<UserRole>());

            return userRole;
        }
        
        // PUT: api/UserRole/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/UserRole/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
