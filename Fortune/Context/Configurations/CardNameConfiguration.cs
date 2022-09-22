using Fortune.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fortune.Context.Configurations
{

    public class CardNameConfiguration : IEntityTypeConfiguration<CardName>
    {
        public void Configure(EntityTypeBuilder<CardName> builder)
        {
            builder.ToTable("CardNames");

            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.Name);

            builder.Property(x => x.Culture);

            builder.HasOne(x => x.Card).WithMany(b => b.CardNames).HasForeignKey(p => p.CardId);

        }
    }
}
