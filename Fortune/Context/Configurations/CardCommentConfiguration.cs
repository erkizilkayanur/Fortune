using Fortune.Context.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fortune.Context.Configurations
{

    public class CardCommentConfiguration : IEntityTypeConfiguration<CardComment>
    {
        public void Configure(EntityTypeBuilder<CardComment> builder)
        {
            builder.ToTable("CardComments");

            builder.Property(x => x.Id).HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(x => x.Comment);

            builder.Property(x => x.Culture);

            builder.HasOne(x => x.Card).WithMany(b => b.CardComments).HasForeignKey(p => p.CardId);

        }
    }
}
