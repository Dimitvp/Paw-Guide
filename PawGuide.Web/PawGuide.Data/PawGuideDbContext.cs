namespace PawGuide.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PawGuideDbContext : IdentityDbContext<User>
    {
        public PawGuideDbContext(DbContextOptions<PawGuideDbContext> options)
            : base(options)
        {
        }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Business>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Businesses)
                .HasForeignKey(a => a.AuthorId);

            builder
                .Entity<Ad>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Ads)
                .HasForeignKey(a => a.AuthorId);

            builder
                .Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
