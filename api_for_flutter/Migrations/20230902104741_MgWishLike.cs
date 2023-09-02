using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgWishLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WishList_IdProd",
                table: "WishList",
                column: "IdProd");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_IdProd",
                table: "Likes",
                column: "IdProd");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Products_IdProd",
                table: "Likes",
                column: "IdProd",
                principalTable: "Products",
                principalColumn: "IdProd");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_Products_IdProd",
                table: "WishList",
                column: "IdProd",
                principalTable: "Products",
                principalColumn: "IdProd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Products_IdProd",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_WishList_Products_IdProd",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_IdProd",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_Likes_IdProd",
                table: "Likes");
        }
    }
}
