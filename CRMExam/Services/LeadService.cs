using System.Security.Claims;

namespace CRMExam.Services
{
    public class LeadService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly HttpContext _httpContext;
        public LeadService(IHttpContextAccessor accessor, AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }

            _httpContext = accessor.HttpContext;
        }

        public async Task<List<Lead>?> GetAll()
        {
            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(stringId, out Guid guidId) == false) return null;

            if (stringId == "admin") { var allLeads = await _context.Leads.ToListAsync(); return allLeads; }

            var leads = await _context.Leads.Where(l => l.SallerId == guidId).ToListAsync();

            return leads;
        }

        public async Task<Lead> CreateLead(Guid id, LeadStatus status)
        {
            var cont = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(stringId, out Guid sallerId) == false || cont == null) return null;

            var newLead = new Lead
            {
                ContractId = cont.Id,
                SallerId = sallerId,
                Status = status
            };

            await _context.Leads.AddAsync(newLead);
            await _context.SaveChangesAsync();
            return newLead;
        }

        public async Task<Lead?> ChangeStatus(Guid leadid, LeadStatus status)
        {
           var lead =   await _context.Leads.FirstOrDefaultAsync(l => l.Id == leadid);
            if(lead == null)   return null;
            lead.Status = status;

            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
            return lead;
        }

    }
}
