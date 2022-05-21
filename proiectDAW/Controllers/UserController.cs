using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Repositories;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;  // dependency injection

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        // [Authorize]
        // [AllowAnonymous]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repository.User.GetAllUsers();
            return Ok(new { users });
        }
    }
}
