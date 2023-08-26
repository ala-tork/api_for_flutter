using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgFeaturesCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Categories_idCategory",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_idCategory",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "idCategory",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "FeatureCategories",
                columns: table => new
                {
                    IdFC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdFeature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureCategories", x => x.IdFC);
                    table.ForeignKey(
                        name: "FK_FeatureCategories_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCateg",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureCategories_Features_IdFeature",
                        column: x => x.IdFeature,
                        principalTable: "Features",
                        principalColumn: "IdF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureCategories_IdCategory",
                table: "FeatureCategories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureCategories_IdFeature",
                table: "FeatureCategories",
                column: "IdFeature");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureCategories");

            migrationBuilder.AddColumn<int>(
                name: "idCategory",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Features_idCategory",
                table: "Features",
                column: "idCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Categories_idCategory",
                table: "Features",
                column: "idCategory",
                principalTable: "Categories",
                principalColumn: "IdCateg",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
