using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCity",
                table: "Products");
        }
    }
}
