using api_for_flutter.Models.AdsFeaturesModel;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.BootsModel;
using api_for_flutter.Models.BrandsModel;
using api_for_flutter.Models.CategoryModels;
using api_for_flutter.Models.CitiesModels;
using api_for_flutter.Models.CountriesModel;
using api_for_flutter.Models.DealsModel;
using api_for_flutter.Models.FeaturesModel;
using api_for_flutter.Models.FeaturesCategoryModel;
using api_for_flutter.Models.FeaturesValuesModel;
using api_for_flutter.Models.ImagesModel;
using api_for_flutter.Models.LikesPublicationModel;
using api_for_flutter.Models.PrizeModel;
using api_for_flutter.Models.UserModel;
using api_for_flutter.Models.WinnersModel;
using api_for_flutter.Models.WishListModel;
using Microsoft.EntityFrameworkCore;
using api_for_flutter.Models.ProductModel;
using api_for_flutter.Models.MagasinModel;
using api_for_flutter.Models.SettingModel;

namespace api_for_flutter.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) {}

        public DbSet<User> Users { get; set; }
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
        public DbSet<Like> Likes { get; set; }
        public DbSet<Winners> Winners { get; set; }
        public DbSet<Prizes> Prizes { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<Boosts> Boosts { get; set; }
        public DbSet<FeatureCategory> FeatureCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<Setting> Setting { get; set; }
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
            modelBuilder.Entity<Ads>()
                .HasOne(a => a.user)
                .WithMany()
                .HasForeignKey(a => a.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Ads>()
                .HasOne(a => a.Boosts)
                .WithMany()
                .HasForeignKey(a => a.IdBoost);
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
            modelBuilder.Entity<Deals>()
                .HasOne(d => d.user)
                .WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Deals>()
                .HasOne(d => d.Prizes)
                .WithMany()
                .HasForeignKey(d => d.IdPrize)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Deals>()
                .HasOne(d => d.Boosts)
                .WithMany()
                .HasForeignKey(d => d.IdBoost);
            modelBuilder.Entity<Product>()
                .HasOne(d => d.Brands)
                .WithMany()
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.NoAction);
            //Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Countries)
                .WithMany()
                .HasForeignKey(p => p.IdCountry)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categories)
                .WithMany()
                .HasForeignKey(p => p.IdCateg)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Cities)
                .WithMany()
                .HasForeignKey(p => p.IdCity)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.user)
                .WithMany()
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Prizes)
                .WithMany()
                .HasForeignKey(p => p.IdPrize)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Boosts)
                .WithMany()
                .HasForeignKey(p => p.IdBoost);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brands)
                .WithMany()
                .HasForeignKey(p => p.IdBrand)
                .OnDelete(DeleteBehavior.NoAction);
            // Category
            modelBuilder.Entity<Categories>()
                .HasMany(c => c.Children)
                .WithOne()
                .HasForeignKey(c => c.idparent)
                .IsRequired(false);
            //Features
           /* modelBuilder.Entity<Features>()
                .HasOne(f => f.Categorie)
                .WithMany()
                .HasForeignKey(f => f.idCategory);*/

            //Feature Values 
            modelBuilder.Entity<FeaturesValues>()
                .HasOne(f => f.features)
                .WithMany()
                .HasForeignKey(f => f.IdF);

            //FeaturesCaegory
            modelBuilder.Entity<FeatureCategory>()
                .HasOne(fc => fc.Category)
                .WithMany()
                .HasForeignKey(fc => fc.IdCategory);

            modelBuilder.Entity<FeatureCategory>()
                .HasOne(fc => fc.Feature)
                .WithMany()
                .HasForeignKey(fc => fc.IdFeature);

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
            modelBuilder.Entity<Images>()
                .HasOne(i => i.Deals)
                .WithMany()
                .HasForeignKey(i => i.IdDeals);
            modelBuilder.Entity<Images>()
                .HasOne(i => i.Prizes)
                .WithMany()
                .HasForeignKey(i => i.IdPrize);
            modelBuilder.Entity<Images>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.IdProduct);
            // Like
            modelBuilder.Entity<Like>()
                .HasOne(l => l.user)
                .WithMany()
                .HasForeignKey(l => l.IdUser);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Deals)
                .WithMany()
                .HasForeignKey(l => l.IdDeal);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Ads)
                .WithMany()
                .HasForeignKey(l => l.IdAd);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.product)
                .WithMany()
                .HasForeignKey(l => l.IdProd);

            //Winners 
            modelBuilder.Entity<Winners>()
                .HasOne(w => w.user)
                .WithMany()
                .HasForeignKey(w => w.IdUser);
            modelBuilder.Entity<Winners>()
                .HasOne(w => w.prizes)
                .WithMany()
                .HasForeignKey(w => w.IdPrize)
                .OnDelete(DeleteBehavior.NoAction);

            //Prizes
            modelBuilder.Entity<Prizes>()
                .HasOne(p => p.user)
                .WithMany()
                .HasForeignKey(p => p.IdUser);

            //WishList

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.user)
                .WithMany()
                .HasForeignKey(w => w.IdUser);

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.ads)
                .WithMany()
                .HasForeignKey(w=>w.IdAd);

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.deals)
                .WithMany()
                .HasForeignKey(w => w.IdDeal);

            modelBuilder.Entity<WishList>()
                .HasOne(w => w.Product)
                .WithMany()
                .HasForeignKey(w => w.IdProd);



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
