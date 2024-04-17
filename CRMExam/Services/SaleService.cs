using System.Security.Claims;

namespace CRMExam.Services
{
    public class SaleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private readonly HttpContext _httpContext;
        public SaleService(IHttpContextAccessor accessor, AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


            if (accessor.HttpContext is null)
            {
                throw new ArgumentException(nameof(accessor.HttpContext));
            }

            _httpContext = accessor.HttpContext;
        }

        public async Task<List<Sale>> GetAll()
        {
           var sales =  await _context.Sales.ToListAsync();
            return sales;
        }

        public async Task<List<Sale>?> MySales()
        {
            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(stringId, out Guid guidId) == false) return null;
            var leads = await _context.Sales.Where(l => l.SallerId == guidId).ToListAsync();
            return leads;
        }

        public async Task<Sale?> MakeDeal(Guid leadId)
        {
            var stringId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(stringId, out Guid sallerId) == false) return null;

            var contract = new Sale
            {
                LeadId = leadId,
                SallerId = sallerId
            };
            await _context.Sales.AddAsync(contract);
           await  _context.SaveChangesAsync();
            return contract;

        }

    }
}
