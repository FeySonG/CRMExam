
namespace CRMExam.Configurations
{
    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasOne<Lead>()
                .WithMany()
                .HasForeignKey(k => k.LeadId);

          
        }
    }
}
