using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Security.API.Models;
using Security.API.Utility;
using Security.Domain.Entities;
using Security.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private static IConfiguration Configuration { get; set; }

        public UserController(IUserRepository userRepository)
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
            userViewModel.Password = CommonHelper.Base64Encode(userViewModel.Password);
            var user = _userRepository.Add(userViewModel.Adapt<User>());

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UserViewModel userViewModel)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
                return NotFound();

            _userRepository.Update(user);
            return Ok();

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]CredentialsViewModel applicationUserViewModel)
        {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";
            if (applicationUserViewModel == null)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }
            var lookupUser = _userRepository.GetByEmail(applicationUserViewModel.Email);
            var lookupUserPassword = CommonHelper.Base64Decode(lookupUser?.Password);

            if ( lookupUserPassword != applicationUserViewModel.Password)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.Name, lookupUser.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Role, lookupUser.UserRoleId.ToString()));

            var claimsPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);



            var auth = JsonConvert.SerializeObject(identity);

            return Redirect($"{Configuration["Clientapp:ClientURL"] }/callback?auth={CommonHelper.Base64Encode(auth)}");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect($"{Configuration["Clientapp:ClientURL"] }/callback");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
