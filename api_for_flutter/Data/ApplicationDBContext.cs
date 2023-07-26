using api_for_flutter.Models;
using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using api_for_flutter.Models.Features;
using api_for_flutter.Models.FeaturesValuesModel;
using api_for_flutter.Models.ImagesModel;
using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

        public DbSet<Features> Features { get; set; }
        public DbSet<FeaturesValues> FeaturesValues { get; set; }
        public DbSet<AdsFeatures> AdsFeatures { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ads
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
            //Features
            modelBuilder.Entity<Features>()
                .HasOne(f => f.Categorie)
                .WithMany()
                .HasForeignKey(f => f.idCategory);
            //Feature Values 
            modelBuilder.Entity<FeaturesValues>()
                .HasOne(f => f.features)
                .WithMany()
                .HasForeignKey(f => f.IdF);
            //AdsFeatures
                //relation with ads
          /*  modelBuilder.Entity<AdsFeatures>()
                .HasOne(af => af.Ads)
                .WithMany()
                .HasForeignKey(af => af.IdAds);
                //relation with Deals
            modelBuilder.Entity<AdsFeatures>()
                .HasOne(af => af.Deals)
                .WithMany()
                .HasForeignKey(af => af.IdDeals);*/

            modelBuilder.Entity<AdsFeatures>()
                .HasOne(af => af.features)
                .WithMany()
                .HasForeignKey(af => af.IdFeature);
                //relation with FeatureValue
            modelBuilder.Entity<AdsFeatures>()
                .HasOne(af => af.FeaturesValues)
                .WithMany()
                .HasForeignKey(af => af.IdFeaturesValues);

            // Images 
            modelBuilder.Entity<Images>()
                .HasOne(i => i.Ads)
                .WithMany()
                .HasForeignKey(i => i.IdAds);




            /* modelBuilder.Entity<FeaturesValues>()
                 .HasOne(f => f.Ads)
                 .WithMany()
                 .HasForeignKey(f => f.IdAds);*/
            /*modelBuilder.Entity<FeaturesValues>()
                 .HasMany(f => f.Ads)
                 .WithMany();*/



        }
    }
}
