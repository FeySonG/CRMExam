
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/user-controller")]
    public class UserController(UserService services) : ControllerBase
    {
        private readonly UserService _services = services;

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LogInAsync(UserLoginDto credentials)
        {
           var user =  await _services.LogInAsync(credentials);

            if (user == null) return Unauthorized("User not found or incorrect data*");

            return Ok("Welcome to Chum Bucket!: " + user.FullName);
        }

        [Authorize(Roles = "admin")]
        [HttpGet( "All")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _services.Users();

            if (users != null) return Ok(users);

            return Unauthorized();

        }
        [Authorize]
        [HttpGet("Info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _services.UserInfoAsync();

            if (user == null) return BadRequest();

            return Ok(user);
        }

        [Authorize(Roles = "admin")]
        [HttpPost ("Add")]
        public async Task<IActionResult> AddUser(UserCreateDto user)
        {
           var info =      await _services.AddUserAsync(user);
            if(info != null) return Ok(user);
             return Unauthorized();
            
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var info = await _services.KillUser(userId);
          
            if(info == false) return BadRequest("User not found or is an Admin!");
            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeUserRole(Guid id, UserRole role)
        {
           var info = await _services.ChangeRoleAsync(id, role);
            if(info == null) return BadRequest();
            return Ok(info);
        }
        [Authorize]
        [HttpPatch("Password")]
        public async Task<IActionResult> ChangeUserPassword(string password)
        {
          var info =  await _services.ChangePasswordAsync(password);
            if(info == false) return BadRequest(info);
            
            return Ok("Succesfully");
        }

      
    }
}
