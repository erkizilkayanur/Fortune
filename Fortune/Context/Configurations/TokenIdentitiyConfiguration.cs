using Fortune.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fortune.Context.Configurations
{

    public class TokenIdentitiyConfiguration : IEntityTypeConfiguration<TokenIdentitiy>
    {
        public void Configure(EntityTypeBuilder<TokenIdentitiy> builder)
        {
            builder.ToTable("TokenIdentities");

            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.Identity);

            builder.Property(x => x.Token);

            builder.Property(x => x.Expire);

            builder.Property(x => x.IsActive);

        }
    }
}
