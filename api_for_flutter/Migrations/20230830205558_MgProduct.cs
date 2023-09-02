using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    CodeBar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePublication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qte = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IdPricesDelevery = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    ImagePrincipale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPrize = table.Column<int>(type: "int", nullable: true),
                    IdCateg = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdMagasin = table.Column<int>(type: "int", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdBoost = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProd);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
