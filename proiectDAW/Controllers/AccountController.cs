using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.Entities;
using proiectDAW.Services.UserServices;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<User> userManager, IUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            var exists = await _userManager.FindByEmailAsync(registerUserDTO.Email);
            if (exists != null)
            {
                return BadRequest("User already registered!");
            }

            var result = await _userService.RegisterUserAsync(registerUserDTO);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest("Could not create user!");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
        {
            var token = await _userService.LoginUser(loginUserDTO);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
