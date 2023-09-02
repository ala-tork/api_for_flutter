using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgSettingUopdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbDiamonProduct",
                table: "Setting",
                newName: "NbDiamondProduct");

            migrationBuilder.RenameColumn(
                name: "NbDiamonDeals",
                table: "Setting",
                newName: "NbDiamondDeals");

            migrationBuilder.RenameColumn(
                name: "NbDiamonAds",
                table: "Setting",
                newName: "NbDiamondAds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbDiamondProduct",
                table: "Setting",
                newName: "NbDiamonProduct");

            migrationBuilder.RenameColumn(
                name: "NbDiamondDeals",
                table: "Setting",
                newName: "NbDiamonDeals");

            migrationBuilder.RenameColumn(
                name: "NbDiamondAds",
                table: "Setting",
                newName: "NbDiamonAds");
        }
    }
}
