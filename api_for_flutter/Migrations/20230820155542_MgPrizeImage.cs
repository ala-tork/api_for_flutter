using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgPrizeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPrize",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_IdPrize",
                table: "Images",
                column: "IdPrize");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Prizes_IdPrize",
                table: "Images",
                column: "IdPrize",
                principalTable: "Prizes",
                principalColumn: "IdPrize");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Prizes_IdPrize",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_IdPrize",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IdPrize",
                table: "Images");
        }
    }
}
