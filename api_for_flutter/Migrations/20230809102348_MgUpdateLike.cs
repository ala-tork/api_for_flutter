using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgUpdateLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Ads_IdAd",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Deals_IdDeal",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "IdDeal",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAd",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Ads_IdAd",
                table: "Likes",
                column: "IdAd",
                principalTable: "Ads",
                principalColumn: "IdAds");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Deals_IdDeal",
                table: "Likes",
                column: "IdDeal",
                principalTable: "Deals",
                principalColumn: "IdDeal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Ads_IdAd",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Deals_IdDeal",
                table: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "IdDeal",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAd",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Ads_IdAd",
                table: "Likes",
                column: "IdAd",
                principalTable: "Ads",
                principalColumn: "IdAds",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Deals_IdDeal",
                table: "Likes",
                column: "IdDeal",
                principalTable: "Deals",
                principalColumn: "IdDeal",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
