using Microsoft.EntityFrameworkCore;

namespace CRMExam
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
