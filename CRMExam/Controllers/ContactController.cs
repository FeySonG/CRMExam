

using Microsoft.AspNetCore.Authorization;

namespace CRMExam.Contracts
{
    [ApiController]
    [Route("api/contact-controller")]
    public class ContactController(ContactService service) : ControllerBase
    {
        private readonly ContactService _service = service;

        [Authorize (Roles = "admin, marketing")]
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
          var contacts = await  _service.GetAllAsync();

            return Ok(contacts);
        }
        [Authorize (Roles = "saller")]
        [HttpGet("Leads")]
        public async Task<IActionResult> GetLeadContacts()
        {
            var leadContacts = await _service.GetLeadAsync();

            return Ok(leadContacts);
        }
        [Authorize (Roles = "marketing")]
        [HttpPost]
        public async Task<IActionResult> CreateContact( ContactDto cont)
        {
            await  _service.CreateAsync(cont);

            return Ok(cont);
        }
        [Authorize(Roles = "saller, marketing")]
        [HttpPut]
        public async Task<IActionResult> ChangeContact(Guid id, ContactDto changes)
        {
           var contact =   await _service.UpdateAsync(id, changes);
            if(contact == null) return NotFound("Contact not found!");
            return Ok(contact);
        }
        [Authorize(Roles = "marketing")]
        [HttpPatch]
        public async Task<IActionResult> ChangeContactStatus(Guid id, ContactStatus status)
        {
            var contact = await _service.ChangeStatusAsync(id, status);
            if (contact == null) return NotFound("Contact not found!");

            return Ok(contact);
        }
    }
}
