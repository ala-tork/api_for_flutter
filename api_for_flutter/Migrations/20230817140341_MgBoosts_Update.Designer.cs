﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_for_flutter.Data;

#nullable disable

namespace api_for_flutter.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230817140341_MgBoosts_Update")]
    partial class MgBoosts_Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_for_flutter.Models.AdsFeaturesModel.AdsFeatures", b =>
                {
                    b.Property<int>("IdAF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAF"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<int?>("IdAds")
                        .HasColumnType("int");

                    b.Property<int?>("IdDeals")
                        .HasColumnType("int");

                    b.Property<int?>("IdFeature")
                        .HasColumnType("int");

                    b.Property<int?>("IdFeaturesValues")
                        .HasColumnType("int");

                    b.Property<string>("MyValues")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAF");

                    b.HasIndex("IdFeature");

                    b.HasIndex("IdFeaturesValues");

                    b.ToTable("AdsFeatures");
                });

            modelBuilder.Entity("api_for_flutter.Models.AdsModels.Ads", b =>
                {
                    b.Property<int>("IdAds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAds"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("DatePublication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdBoost")
                        .HasColumnType("int");

                    b.Property<int>("IdCateg")
                        .HasColumnType("int");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<int>("IdCountrys")
                        .HasColumnType("int");

                    b.Property<int>("IdPricesDelevery")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("ImagePrinciple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAds");

                    b.HasIndex("IdBoost");

                    b.HasIndex("IdCateg");

                    b.HasIndex("IdCity");

                    b.HasIndex("IdCountrys");

                    b.HasIndex("IdUser");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("api_for_flutter.Models.BootsModel.Boosts", b =>
                {
                    b.Property<int>("IdBoost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBoost"));

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HasLinks")
                        .HasColumnType("int");

                    b.Property<int?>("InFirstLogin")
                        .HasColumnType("int");

                    b.Property<int?>("InFooter")
                        .HasColumnType("int");

                    b.Property<int?>("InRelatedPost")
                        .HasColumnType("int");

                    b.Property<int?>("InSideBar")
                        .HasColumnType("int");

                    b.Property<int?>("InSliders")
                        .HasColumnType("int");

                    b.Property<int?>("MaxDurationPerDay")
                        .HasColumnType("int");

                    b.Property<int?>("Orders")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("TitleBoost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBoost");

                    b.ToTable("Boosts");
                });

            modelBuilder.Entity("api_for_flutter.Models.BrandsModel.Brands", b =>
                {
                    b.Property<int>("IdBrand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBrand"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBrand");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("api_for_flutter.Models.CategoryModels.Categories", b =>
                {
                    b.Property<int>("IdCateg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCateg"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("idparent")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCateg");

                    b.HasIndex("idparent");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("api_for_flutter.Models.CitiesModels.Cities", b =>
                {
                    b.Property<int>("IdCity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCity"));

                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCity");

                    b.HasIndex("IdCountry");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("api_for_flutter.Models.CountriesModel.Countries", b =>
                {
                    b.Property<int>("IdCountrys")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCountrys"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCountrys");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("api_for_flutter.Models.DealsModel.Deals", b =>
                {
                    b.Property<int>("IdDeal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDeal"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("DateEND")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DatePublication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int?>("IdBoost")
                        .HasColumnType("int");

                    b.Property<int>("IdBrand")
                        .HasColumnType("int");

                    b.Property<int>("IdCateg")
                        .HasColumnType("int");

                    b.Property<int>("IdCity")
                        .HasColumnType("int");

                    b.Property<int>("IdCountrys")
                        .HasColumnType("int");

                    b.Property<int?>("IdPricesDelevery")
                        .HasColumnType("int");

                    b.Property<int?>("IdPrize")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("ImagePrinciple")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Locations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDeal");

                    b.HasIndex("IdBoost");

                    b.HasIndex("IdBrand");

                    b.HasIndex("IdCateg");

                    b.HasIndex("IdCity");

                    b.HasIndex("IdCountrys");

                    b.HasIndex("IdPrize");

                    b.HasIndex("IdUser");

                    b.ToTable("Deals");
                });

            modelBuilder.Entity("api_for_flutter.Models.Features.Features", b =>
                {
                    b.Property<int>("IdF")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdF"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCategory")
                        .HasColumnType("int");

                    b.HasKey("IdF");

                    b.HasIndex("idCategory");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("api_for_flutter.Models.FeaturesValuesModel.FeaturesValues", b =>
                {
                    b.Property<int>("IdFv")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFv"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<int>("IdF")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFv");

                    b.HasIndex("IdF");

                    b.ToTable("FeaturesValues");
                });

            modelBuilder.Entity("api_for_flutter.Models.ImagesModel.Images", b =>
                {
                    b.Property<int>("IdImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImage"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<int?>("IdAds")
                        .HasColumnType("int");

                    b.Property<int?>("IdDeals")
                        .HasColumnType("int");

                    b.Property<int?>("IdProduct")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdImage");

                    b.HasIndex("IdAds");

                    b.HasIndex("IdDeals");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("api_for_flutter.Models.LikesPublicationModel.Like", b =>
                {
                    b.Property<int>("IdLP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLP"));

                    b.Property<int?>("IdAd")
                        .HasColumnType("int");

                    b.Property<int?>("IdDeal")
                        .HasColumnType("int");

                    b.Property<int?>("IdProd")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("MyDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLP");

                    b.HasIndex("IdAd");

                    b.HasIndex("IdDeal");

                    b.HasIndex("IdUser");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("api_for_flutter.Models.PrizeModel.Prizes", b =>
                {
                    b.Property<int>("IdPrize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrize"));

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("DatePrize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrize");

                    b.HasIndex("IdUser");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("api_for_flutter.Models.UserModel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateInscription")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("api_for_flutter.Models.WinnersModel.Winners", b =>
                {
                    b.Property<int>("IdWinner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdWinner"));

                    b.Property<string>("DateWin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPrize")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("PriceRecived")
                        .HasColumnType("int");

                    b.HasKey("IdWinner");

                    b.HasIndex("IdPrize");

                    b.HasIndex("IdUser");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("api_for_flutter.Models.WishListModel.WishList", b =>
                {
                    b.Property<int>("Idwish")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Idwish"));

                    b.Property<int?>("IdAd")
                        .HasColumnType("int");

                    b.Property<int?>("IdDeal")
                        .HasColumnType("int");

                    b.Property<int?>("IdProd")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("MyDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Idwish");

                    b.HasIndex("IdAd");

                    b.HasIndex("IdDeal");

                    b.HasIndex("IdUser");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("api_for_flutter.Models.AdsFeaturesModel.AdsFeatures", b =>
                {
                    b.HasOne("api_for_flutter.Models.Features.Features", "features")
                        .WithMany()
                        .HasForeignKey("IdFeature");

                    b.HasOne("api_for_flutter.Models.FeaturesValuesModel.FeaturesValues", "FeaturesValues")
                        .WithMany()
                        .HasForeignKey("IdFeaturesValues");

                    b.Navigation("FeaturesValues");

                    b.Navigation("features");
                });

            modelBuilder.Entity("api_for_flutter.Models.AdsModels.Ads", b =>
                {
                    b.HasOne("api_for_flutter.Models.BootsModel.Boosts", "Boosts")
                        .WithMany()
                        .HasForeignKey("IdBoost");

                    b.HasOne("api_for_flutter.Models.CategoryModels.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("IdCateg")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.CitiesModels.Cities", "Cities")
                        .WithMany()
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.CountriesModel.Countries", "Countries")
                        .WithMany()
                        .HasForeignKey("IdCountrys")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Boosts");

                    b.Navigation("Categories");

                    b.Navigation("Cities");

                    b.Navigation("Countries");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.CategoryModels.Categories", b =>
                {
                    b.HasOne("api_for_flutter.Models.CategoryModels.Categories", null)
                        .WithMany("Children")
                        .HasForeignKey("idparent");
                });

            modelBuilder.Entity("api_for_flutter.Models.CitiesModels.Cities", b =>
                {
                    b.HasOne("api_for_flutter.Models.CountriesModel.Countries", "Countries")
                        .WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countries");
                });

            modelBuilder.Entity("api_for_flutter.Models.DealsModel.Deals", b =>
                {
                    b.HasOne("api_for_flutter.Models.BootsModel.Boosts", "Boosts")
                        .WithMany()
                        .HasForeignKey("IdBoost");

                    b.HasOne("api_for_flutter.Models.BrandsModel.Brands", "Brands")
                        .WithMany()
                        .HasForeignKey("IdBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.CategoryModels.Categories", "Categories")
                        .WithMany()
                        .HasForeignKey("IdCateg")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.CitiesModels.Cities", "Cities")
                        .WithMany()
                        .HasForeignKey("IdCity")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.CountriesModel.Countries", "Countries")
                        .WithMany()
                        .HasForeignKey("IdCountrys")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.PrizeModel.Prizes", "Prizes")
                        .WithMany()
                        .HasForeignKey("IdPrize")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Boosts");

                    b.Navigation("Brands");

                    b.Navigation("Categories");

                    b.Navigation("Cities");

                    b.Navigation("Countries");

                    b.Navigation("Prizes");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.Features.Features", b =>
                {
                    b.HasOne("api_for_flutter.Models.CategoryModels.Categories", "Categorie")
                        .WithMany()
                        .HasForeignKey("idCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("api_for_flutter.Models.FeaturesValuesModel.FeaturesValues", b =>
                {
                    b.HasOne("api_for_flutter.Models.Features.Features", "features")
                        .WithMany()
                        .HasForeignKey("IdF")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("features");
                });

            modelBuilder.Entity("api_for_flutter.Models.ImagesModel.Images", b =>
                {
                    b.HasOne("api_for_flutter.Models.AdsModels.Ads", "Ads")
                        .WithMany()
                        .HasForeignKey("IdAds");

                    b.HasOne("api_for_flutter.Models.DealsModel.Deals", "Deals")
                        .WithMany()
                        .HasForeignKey("IdDeals");

                    b.Navigation("Ads");

                    b.Navigation("Deals");
                });

            modelBuilder.Entity("api_for_flutter.Models.LikesPublicationModel.Like", b =>
                {
                    b.HasOne("api_for_flutter.Models.AdsModels.Ads", "Ads")
                        .WithMany()
                        .HasForeignKey("IdAd");

                    b.HasOne("api_for_flutter.Models.DealsModel.Deals", "Deals")
                        .WithMany()
                        .HasForeignKey("IdDeal");

                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ads");

                    b.Navigation("Deals");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.PrizeModel.Prizes", b =>
                {
                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.WinnersModel.Winners", b =>
                {
                    b.HasOne("api_for_flutter.Models.PrizeModel.Prizes", "Prizes")
                        .WithMany()
                        .HasForeignKey("IdPrize")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prizes");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.WishListModel.WishList", b =>
                {
                    b.HasOne("api_for_flutter.Models.AdsModels.Ads", "ads")
                        .WithMany()
                        .HasForeignKey("IdAd");

                    b.HasOne("api_for_flutter.Models.DealsModel.Deals", "deals")
                        .WithMany()
                        .HasForeignKey("IdDeal");

                    b.HasOne("api_for_flutter.Models.UserModel.User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ads");

                    b.Navigation("deals");

                    b.Navigation("user");
                });

            modelBuilder.Entity("api_for_flutter.Models.CategoryModels.Categories", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
