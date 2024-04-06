

namespace CRMExam.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(c => c.Email)
                  .IsUnique(true)
                  .IsClustered(false);
                
        }
    }
}
