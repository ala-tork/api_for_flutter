using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    IdBrand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCateg = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idparent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCateg);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    IdCountrys = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.IdCountrys);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IdCity);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Countries",
                        principalColumn: "IdCountrys",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    IdAds = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImagePrinciple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCateg = table.Column<int>(type: "int", nullable: false),
                    IdCountrys = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    Locations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.IdAds);
                    table.ForeignKey(
                        name: "FK_Ads_Categories_IdCateg",
                        column: x => x.IdCateg,
                        principalTable: "Categories",
                        principalColumn: "IdCateg");
                    table.ForeignKey(
                        name: "FK_Ads_Cities_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Cities",
                        principalColumn: "IdCity");
                    table.ForeignKey(
                        name: "FK_Ads_Countries_IdCountrys",
                        column: x => x.IdCountrys,
                        principalTable: "Countries",
                        principalColumn: "IdCountrys");
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    IdDeal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePrinciple = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCateg = table.Column<int>(type: "int", nullable: false),
                    IdCountrys = table.Column<int>(type: "int", nullable: false),
                    IdCity = table.Column<int>(type: "int", nullable: false),
                    IdBrand = table.Column<int>(type: "int", nullable: false),
                    Locations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    IdCountry = table.Column<int>(type: "int", nullable: false),
                    IdIdCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.IdDeal);
                    table.ForeignKey(
                        name: "FK_Deals_Brands_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Brands",
                        principalColumn: "IdBrand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deals_Categories_IdCateg",
                        column: x => x.IdCateg,
                        principalTable: "Categories",
                        principalColumn: "IdCateg");
                    table.ForeignKey(
                        name: "FK_Deals_Cities_IdCity",
                        column: x => x.IdCity,
                        principalTable: "Cities",
                        principalColumn: "IdCity");
                    table.ForeignKey(
                        name: "FK_Deals_Countries_IdCountrys",
                        column: x => x.IdCountrys,
                        principalTable: "Countries",
                        principalColumn: "IdCountrys");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IdCateg",
                table: "Ads",
                column: "IdCateg");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IdCity",
                table: "Ads",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_IdCountrys",
                table: "Ads",
                column: "IdCountrys");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_IdCountry",
                table: "Cities",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdBrand",
                table: "Deals",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdCateg",
                table: "Deals",
                column: "IdCateg");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdCity",
                table: "Deals",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_IdCountrys",
                table: "Deals",
                column: "IdCountrys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
