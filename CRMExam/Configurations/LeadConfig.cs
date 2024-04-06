
namespace CRMExam.Configurations
{
    public class LeadConfig : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasOne<Contact>()
                .WithOne()
                .HasForeignKey<Lead>(c => c.ContractId);

        
        }
    }
}
