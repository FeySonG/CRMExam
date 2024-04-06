

namespace CRMExam.Configurations
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne<User>()  
           .WithMany()
            .HasForeignKey(c => c.MarketingId);



        }
    }
}
