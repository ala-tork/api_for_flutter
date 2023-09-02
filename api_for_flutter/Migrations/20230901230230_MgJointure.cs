using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgJointure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdBoost",
                table: "Products",
                column: "IdBoost");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdBrand",
                table: "Products",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCateg",
                table: "Products",
                column: "IdCateg");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCity",
                table: "Products",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdCountry",
                table: "Products",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdPrize",
                table: "Products",
                column: "IdPrize");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdUser",
                table: "Products",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Boosts_IdBoost",
                table: "Products",
                column: "IdBoost",
                principalTable: "Boosts",
                principalColumn: "IdBoost");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products",
                column: "IdBrand",
                principalTable: "Brands",
                principalColumn: "IdBrand");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_IdCateg",
                table: "Products",
                column: "IdCateg",
                principalTable: "Categories",
                principalColumn: "IdCateg");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_IdCity",
                table: "Products",
                column: "IdCity",
                principalTable: "Cities",
                principalColumn: "IdCity");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Countries_IdCountry",
                table: "Products",
                column: "IdCountry",
                principalTable: "Countries",
                principalColumn: "IdCountrys");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Prizes_IdPrize",
                table: "Products",
                column: "IdPrize",
                principalTable: "Prizes",
                principalColumn: "IdPrize");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_IdUser",
                table: "Products",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Boosts_IdBoost",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_IdBrand",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_IdCateg",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_IdCity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Countries_IdCountry",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Prizes_IdPrize",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_IdUser",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdBoost",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdBrand",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCateg",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCity",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdCountry",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdPrize",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdUser",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Products");
        }
    }
}
