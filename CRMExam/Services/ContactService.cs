using CRMExam.Contracts;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace CRMExam.Services
{
    public class ContactService 
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly HttpContext _httpContext;
        public ContactService(IHttpContextAccessor accessor, AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }

            _httpContext = accessor.HttpContext;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            var contacts = await  _context.Contacts.ToListAsync();


            return contacts;
        } 

        public async Task<List<Contact>> GetLeadAsync()
        {
            var leadContacts = await _context.Contacts.Where(c => c.Status == ContactStatus.Lead)
               .ToListAsync();


            return leadContacts;
        }

        public async Task<bool> CreateAsync(ContactDto contact )
        {
            var newContact = _mapper.Map<Contact>(contact);

            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(stringId, out Guid guidId) == false) return false;
            newContact.MarketingId = guidId;

            await _context.Contacts.AddAsync(newContact);
            await _context.SaveChangesAsync();
            return true;
        } 

        public async Task<ContactDto?> UpdateAsync(Guid id, ContactDto changes)
        {
            var updatedContact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (updatedContact == null) return null;

            updatedContact.Name = (!string.IsNullOrWhiteSpace(updatedContact.Name) && updatedContact.Name != "string") ? updatedContact.Name : changes.Name;
            updatedContact.Surname = (!string.IsNullOrWhiteSpace(updatedContact.Surname) && updatedContact.Surname != "string") ? updatedContact.Surname : changes.Surname;
            updatedContact.Patronymic = (!string.IsNullOrWhiteSpace(updatedContact.Patronymic) && updatedContact.Patronymic != "string") ? updatedContact.Patronymic : changes.Patronymic;
            updatedContact.PhoneNumber = (!string.IsNullOrWhiteSpace(updatedContact.PhoneNumber) && updatedContact.PhoneNumber != "string") ? updatedContact.PhoneNumber : changes.PhoneNumber;
            updatedContact.Email = (!string.IsNullOrWhiteSpace(updatedContact.Email) && updatedContact.Email != "string") ? updatedContact.Email : changes.Email;

            _context.Contacts.Update(updatedContact);
            await _context.SaveChangesAsync();
            return changes;
        } 

        public async Task<ContactDto?> ChangeStatusAsync(Guid id, ContactStatus status)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return null;
             contact.Status = status;

            var contactDto = _mapper.Map<ContactDto>(contact);

            
            await _context.SaveChangesAsync();

            return contactDto;
        }

    }
}
