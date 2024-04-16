using Microsoft.AspNetCore.Authorization;

namespace CRMExam.Controllers
{
    [ApiController]
    [Route("api/lead-controller")]
    public class LeadController(LeadService service) : ControllerBase
    {
        private readonly LeadService _service = service;
       
        [Authorize(Roles = "saller,admin")]
        [HttpGet]
        public async Task<IActionResult> GetLeads()
        {
            var leads = await _service.GetAll();
            return Ok(leads);
        }

        [Authorize(Roles = "saller")]
        [HttpPost]
        public async Task<IActionResult> CreateLead(Guid id, LeadStatus status)
        {
            var info = await _service.CreateLead(id, status);
            if (info == null)  return BadRequest("Contact not Found!");

            return Ok(info);
        }

        [Authorize(Roles = "saller")]
        [HttpPatch]
        public async Task<IActionResult> ChangeLeadStatus(Guid leadId, LeadStatus status)
        {
            var info = await _service.ChangeStatus(leadId, status);
            if (info == null) return BadRequest("Lead is not found!");

            return Ok(info);
        }
    }
}
