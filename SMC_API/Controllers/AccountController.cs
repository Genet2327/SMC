using Microsoft.AspNetCore.Mvc;
using SMC_API.Dtos.Account;
using SMC_API.Service;
using SMC_Entities.Autentication;
using System.Threading.Tasks;

namespace SMC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _userService;
        public AccountController(IAccountService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
        {
            var result = await _userService.AddRoleAsync(model);
            return Ok(result);
        }
    }
}
