using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MGDeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePrinciple",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DatePublication",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DateEND",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdBoost",
                table: "Deals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPricesDelevery",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPrize",
                table: "Deals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdDeals",
                table: "Images",
                column: "IdDeals");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdUser",
                table: "Deals",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IdUser",
                table: "Ads",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Users_IdUser",
                table: "Ads",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Users_IdUser",
                table: "Deals",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Deals_IdDeals",
                table: "Images",
                column: "IdDeals",
                principalTable: "Deals",
                principalColumn: "IdDeal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Users_IdUser",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Users_IdUser",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Deals_IdDeals",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IdDeals",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Deals_IdUser",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Ads_IdUser",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IdBoost",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "IdPricesDelevery",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "IdPrize",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Deals");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePrinciple",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DatePublication",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateEND",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
