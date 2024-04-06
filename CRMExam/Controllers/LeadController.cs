namespace CRMExam.Controllers
{
    [ApiController]
    [Route("api/lead-controller")]
    public class LeadController : ControllerBase
    {
        [HttpGet]
        public Task<IActionResult> GetContacts()
        {
            return null;
        }

        [HttpPost]
        public Task<IActionResult> CreateLead()
        {
            return null;
        }

        [HttpPatch]
        public Task<IActionResult> ChangeOfStatus()
        {
            return null;
        }

    }
}
