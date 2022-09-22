using Fortune.Models;
using Fortune.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fortune.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        [HttpPost("login/")]
        [Produces("application/json", Type = typeof(string))]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var data = _authorizationService.Login(loginModel);

            return Ok(data);
        }
    }
}
