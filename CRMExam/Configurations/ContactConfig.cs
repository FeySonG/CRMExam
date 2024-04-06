using CRMExam.Entities;
using CRMExam.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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
