using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class update_AdsFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdsFeatures_Ads_IdAds",
                table: "AdsFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_AdsFeatures_Deals_IdDeals",
                table: "AdsFeatures");

            migrationBuilder.DropIndex(
                name: "IX_AdsFeatures_IdAds",
                table: "AdsFeatures");

            migrationBuilder.DropIndex(
                name: "IX_AdsFeatures_IdDeals",
                table: "AdsFeatures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AdsFeatures_IdAds",
                table: "AdsFeatures",
                column: "IdAds");

            migrationBuilder.CreateIndex(
                name: "IX_AdsFeatures_IdDeals",
                table: "AdsFeatures",
                column: "IdDeals");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsFeatures_Ads_IdAds",
                table: "AdsFeatures",
                column: "IdAds",
                principalTable: "Ads",
                principalColumn: "IdAds");

            migrationBuilder.AddForeignKey(
                name: "FK_AdsFeatures_Deals_IdDeals",
                table: "AdsFeatures",
                column: "IdDeals",
                principalTable: "Deals",
                principalColumn: "IdDeal");
        }
    }
}
