using Challenge.Core.Interfaces;
using Challenge.Core.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("auth")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDTO userLoginDto)
        {
            var result = await _userService.LoginAsync(userLoginDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(result.isError() ? 500 : 400, result);
        }
        
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterDto dto)
        {
            var result = await _userService.Insert(dto);
            if (result.Success)
            {
                return Ok(result);
            }

            return StatusCode(result.isError() ? 500 : 400, result);
        }
    }
}
