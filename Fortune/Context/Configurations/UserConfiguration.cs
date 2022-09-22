using Fortune.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fortune.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.Name);

            builder.Property(x => x.Email);

            builder.Property(x => x.Phone);

            builder.Property(x => x.Password);
            builder.Property(x => x.PasswordSalt);

            builder.Property(x => x.Type);

            builder.Property(x => x.IsActive);


        }
    }
}


