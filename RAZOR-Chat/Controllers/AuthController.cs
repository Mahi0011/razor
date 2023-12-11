using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RAZOR_Chat.Interface;
using RAZOR_Chat.Models;
using RAZOR_Chat.Service;
using System.Security.Cryptography.X509Certificates;

namespace RAZOR_Chat.Controllers
{
    [DisableCors]
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
       public async Task<IActionResult> Register([FromBody]User user)
       {
            var r = Response<object>.setResponse(false, null, "failed");
            var resp = await _authService.Register(user);
            return new ObjectResult(resp);
       }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin user)
        {
            var r = Response<object>.setResponse(false, null, "failed");
            var resp = await _authService.Login(user);
            return new ObjectResult(resp);
        }
        [HttpGet, Authorize]
        public string getdata()
        {
            var username = User?.Identity?.Name;
            return "wjkersodj";
        }
    }
    
}
