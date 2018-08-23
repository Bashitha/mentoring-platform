
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Security.API.Models;
using Security.API.Utility;
using Security.Domain.Entities;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Security.Domain.IRepositories;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(IUserRepository userRepository, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(credentials.Email, credentials.Password);
            if (identity == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, credentials.Email, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            return new OkObjectResult(jwt);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);
            //var lookupUser = _userRepository.GetByEmail(applicationUserViewModel.Email);
           // var lookupUserPassword = CommonHelper.Base64Decode(lookupUser?.Password);

           // if (lookupUserPassword != applicationUserViewModel.Password)

                // get the user to verifty
            var userToVerify = _userRepository.GetByEmail(email);
            var userPassword = System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(userToVerify?.Password));//CommonHelper.Base64Decode(userToVerify?.Password);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (userPassword == password)
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(email, userToVerify.Id.ToString()));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}