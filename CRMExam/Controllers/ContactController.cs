

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/contact-controller")]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetContacts()
        {
            return null;
        }

        [HttpGet]
        public Task<IActionResult> GetLeadContacts()
        {
            return null;
        }

        [HttpPost]
        public Task<IActionResult> CreateContact()
        {
            return null;
        }

        [HttpPatch]
        public Task<IActionResult> ChangeContact()
        {
            return null;
        }

        [HttpPatch]
        public Task<IActionResult> ChangeContactStatus()
        {
            return null;
        }
    }
}
