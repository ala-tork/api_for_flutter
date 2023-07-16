using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class mg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "idparent",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_idparent",
                table: "Categories",
                column: "idparent");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_idparent",
                table: "Categories",
                column: "idparent",
                principalTable: "Categories",
                principalColumn: "IdCateg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_idparent",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_idparent",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "idparent",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
