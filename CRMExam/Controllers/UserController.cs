using Microsoft.AspNetCore.Mvc;

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/user-controller")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> LogIn()
        {
            return null;
        }

        [HttpGet]
        public Task<IActionResult> GetUsers()
        {
            return null;
        }

        [HttpGet]
        public Task<IActionResult> GetUserInfo()
        {
            return null;
        }

        [HttpPost]
        public Task<IActionResult> AddUser()
        {
            return null;
        }

        [HttpDelete]
        public Task<IActionResult> DeleteUser()
        {
            return null;
        }

        [HttpPatch]
        public Task<IActionResult> ChangeUserRole()
        {
            return null;
        }

        [HttpPatch]
        public Task<IActionResult> ChangeUserPassword()
        {
            return null;
        }
    }
}
