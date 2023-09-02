using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MGUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "AdsFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdProduct",
                table: "Images",
                column: "IdProduct");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images",
                column: "IdProduct",
                principalTable: "Products",
                principalColumn: "IdProd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_IdProduct",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IdProduct",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "AdsFeatures");
        }
    }
}
