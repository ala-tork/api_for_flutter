using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_for_flutter.Migrations
{
    /// <inheritdoc />
    public partial class MgSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    IdSetting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrivacyPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyRetour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PROUserMonthPrice = table.Column<double>(type: "float", nullable: true),
                    PROEntrepriseMonthPrice = table.Column<double>(type: "float", nullable: true),
                    TransfertCommision = table.Column<double>(type: "float", nullable: true),
                    MinimumSubscriptionDuration = table.Column<int>(type: "int", nullable: true),
                    StandardAnnonceMaxDuration = table.Column<int>(type: "int", nullable: true),
                    StandardDealsMaxDuration = table.Column<int>(type: "int", nullable: true),
                    StandardMaxMagasin = table.Column<int>(type: "int", nullable: true),
                    StandardAccountMaxAnnonces = table.Column<int>(type: "int", nullable: true),
                    StandardAccountMaxDeals = table.Column<int>(type: "int", nullable: true),
                    StandardAccountMaxProduts = table.Column<int>(type: "int", nullable: true),
                    ModeMagasinAndDeals = table.Column<bool>(type: "bit", nullable: true),
                    StandardAchatCommision = table.Column<double>(type: "float", nullable: true),
                    StandardAccountMaxPoints = table.Column<int>(type: "int", nullable: true),
                    MinimumAddAnnoncePoints = table.Column<int>(type: "int", nullable: true),
                    MinimumAddDealsPoints = table.Column<int>(type: "int", nullable: true),
                    MinimumAddProductsPoints = table.Column<int>(type: "int", nullable: true),
                    CreationRatingPreviewForStandardAccount = table.Column<bool>(type: "bit", nullable: true),
                    BoostAds = table.Column<bool>(type: "bit", nullable: true),
                    UpgradeAccount = table.Column<bool>(type: "bit", nullable: true),
                    BuyPoints = table.Column<bool>(type: "bit", nullable: true),
                    PremiumAccount = table.Column<bool>(type: "bit", nullable: true),
                    RatingPreview = table.Column<bool>(type: "bit", nullable: true),
                    NbDiamonAds = table.Column<int>(type: "int", nullable: false),
                    NbDiamonDeals = table.Column<int>(type: "int", nullable: false),
                    NbDiamonProduct = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.IdSetting);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");
        }
    }
}
