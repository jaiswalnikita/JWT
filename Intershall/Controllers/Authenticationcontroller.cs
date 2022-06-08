using Intershall.Models;
using Intershall.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intershall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Authenticationcontroller : ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public Authenticationcontroller(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateService.Authenticate(model.Email, model.Password);
            if (user == null)
                return BadRequest(new { message = "Email and Password is incorrect" });
            return Ok(user);
        }
    }
}
