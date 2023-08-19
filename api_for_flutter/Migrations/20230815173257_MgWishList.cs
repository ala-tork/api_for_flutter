using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgWishList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WishList",
                columns: table => new
                {
                    Idwish = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdDeal = table.Column<int>(type: "int", nullable: true),
                    IdProd = table.Column<int>(type: "int", nullable: true),
                    IdAd = table.Column<int>(type: "int", nullable: true),
                    MyDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishList", x => x.Idwish);
                    table.ForeignKey(
                        name: "FK_WishList_Ads_IdAd",
                        column: x => x.IdAd,
                        principalTable: "Ads",
                        principalColumn: "IdAds");
                    table.ForeignKey(
                        name: "FK_WishList_Deals_IdDeal",
                        column: x => x.IdDeal,
                        principalTable: "Deals",
                        principalColumn: "IdDeal");
                    table.ForeignKey(
                        name: "FK_WishList_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WishList_IdAd",
                table: "WishList",
                column: "IdAd");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_IdDeal",
                table: "WishList",
                column: "IdDeal");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_IdUser",
                table: "WishList",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishList");
        }
    }
}
