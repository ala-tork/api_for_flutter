using api_for_flutter.Models;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.CategoryModels;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) {}

        public DbSet<Ads> Ads { get; set; }
        public DbSet<Deals> Deals { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; } 
        public DbSet<Brands> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ads>()
                .HasOne(a => a.Countries)
                .WithMany()
                .HasForeignKey(a => a.IdCountrys)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ads>()
                .HasOne(a => a.Categories)
                .WithMany()
                .HasForeignKey(a => a.IdCateg)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ads>()
                .HasOne(a => a.Cities)
                .WithMany()
                .HasForeignKey(a => a.IdCity)
                .OnDelete(DeleteBehavior.NoAction);
            //deals
            modelBuilder.Entity<Deals>()
                .HasOne(d => d.Countries)
                .WithMany()
                .HasForeignKey(d => d.IdCountrys)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Deals>()
                .HasOne(d => d.Categories)
                .WithMany()
                .HasForeignKey(d => d.IdCateg)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Deals>()
                .HasOne(d => d.Cities)
                .WithMany()
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.NoAction);

            // Category
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Children)
                .WithOne()
                .HasForeignKey(c => c.idparent)
                .IsRequired(false);
        }
    }
}
