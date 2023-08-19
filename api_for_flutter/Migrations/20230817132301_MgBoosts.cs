using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgBoosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPricesDelevery",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Boosts",
                columns: table => new
                {
                    IdBoost = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleBoost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxDurationPerDay = table.Column<int>(type: "int", nullable: false),
                    InSliders = table.Column<int>(type: "int", nullable: false),
                    InSideBar = table.Column<int>(type: "int", nullable: false),
                    InFooter = table.Column<int>(type: "int", nullable: false),
                    InRelatedPost = table.Column<int>(type: "int", nullable: false),
                    InFirstLogin = table.Column<int>(type: "int", nullable: false),
                    HasLinks = table.Column<int>(type: "int", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boosts", x => x.IdBoost);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdBoost",
                table: "Deals",
                column: "IdBoost");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IdBoost",
                table: "Ads",
                column: "IdBoost");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Boosts_IdBoost",
                table: "Ads",
                column: "IdBoost",
                principalTable: "Boosts",
                principalColumn: "IdBoost");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Boosts_IdBoost",
                table: "Deals",
                column: "IdBoost",
                principalTable: "Boosts",
                principalColumn: "IdBoost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Boosts_IdBoost",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Boosts_IdBoost",
                table: "Deals");

            migrationBuilder.DropTable(
                name: "Boosts");

            migrationBuilder.DropIndex(
                name: "IX_Deals_IdBoost",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Ads_IdBoost",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IdPricesDelevery",
                table: "Ads");
        }
    }
}
