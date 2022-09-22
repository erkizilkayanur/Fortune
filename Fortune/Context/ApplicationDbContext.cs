using Fortune.Context.Configurations;
using Fortune.Context.Model;
using Microsoft.EntityFrameworkCore;

namespace Fortune.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardName> CardNames { get; set; }
        public DbSet<CardComment> CardComments { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<TokenIdentitiy> TokenIdentities { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfigurations());
            modelBuilder.ApplyConfiguration(new CardNameConfiguration());
            modelBuilder.ApplyConfiguration(new CardCommentConfiguration());
            modelBuilder.ApplyConfiguration(new CultureConfiguration());
            modelBuilder.ApplyConfiguration(new TokenIdentitiyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());



            base.OnModelCreating(modelBuilder);
        }

    }
}
