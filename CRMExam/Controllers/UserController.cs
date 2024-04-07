

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/user-controller")]
    public class UserController : ControllerBase
    {
        [HttpPost("LogIn",Name = "LogIn")]
        public Task<IActionResult> LogIn()
        {
            return null;
        }

        [HttpGet]
        public Task<IActionResult> GetUsers()
        {
            return null;
        }

        [HttpGet("{id}")]
        public Task<IActionResult> GetUserInfo(Guid id)
        {
            return null;
        }

        [HttpPost( "Create",Name = "Create User" ) ]
        public Task<IActionResult> AddUser()
        {
            return null;
        }

        [HttpDelete]
        public Task<IActionResult> DeleteUser()
        {
            return null;
        }

        [HttpPut]
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
