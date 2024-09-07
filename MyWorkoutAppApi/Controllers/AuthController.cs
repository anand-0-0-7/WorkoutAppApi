using Microsoft.AspNetCore.Mvc;
using MyWorkoutAppApi.Data;
using MyWorkoutAppApi.Models;
using System.Threading.Tasks;

namespace MyWorkoutAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            if (await _userRepository.UserExistsAsync(user.Email))
                return BadRequest("User already exists.");

            await _userRepository.AddUserAsync(user);
            return Ok("User registered successfully.");
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            var existingUser = await _userRepository.ValidateUserAsync(user.Email, user.Password);

            if (existingUser == null)
                return Unauthorized("Invalid email or password.");

            return Ok("Sign-in successful.");
        }
    }
}
