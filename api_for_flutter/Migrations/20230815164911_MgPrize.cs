using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgPrize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    IdPrize = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePrize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.IdPrize);
                    table.ForeignKey(
                        name: "FK_Prizes_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Winners_IdPrize",
                table: "Winners",
                column: "IdPrize");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdPrize",
                table: "Deals",
                column: "IdPrize");

            migrationBuilder.CreateIndex(
                name: "IX_Prizes_IdUser",
                table: "Prizes",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Prizes_IdPrize",
                table: "Deals",
                column: "IdPrize",
                principalTable: "Prizes",
                principalColumn: "IdPrize");

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Prizes_IdPrize",
                table: "Winners",
                column: "IdPrize",
                principalTable: "Prizes",
                principalColumn: "IdPrize");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Prizes_IdPrize",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Prizes_IdPrize",
                table: "Winners");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropIndex(
                name: "IX_Winners_IdPrize",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Deals_IdPrize",
                table: "Deals");
        }
    }
}
