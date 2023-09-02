using api_for_flutter.Data;
using api_for_flutter.Models.SettingModel;
using api_for_flutter.Services.SettingServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class SettingService : ISettingService
{
    private readonly ApplicationDBContext _context;

    public SettingService(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<Setting> CreateSetting(CreateSetting setting)
    {
        var newSetting = new Setting
        {
            PrivacyPolicy = setting.PrivacyPolicy,
            PolicyRetour = setting.PolicyRetour,
            TermsAndConditions = setting.TermsAndConditions,
            PROUserMonthPrice = setting.PROUserMonthPrice,
            PROEntrepriseMonthPrice = setting.PROEntrepriseMonthPrice,
            TransfertCommision = setting.TransfertCommision,
            MinimumSubscriptionDuration = setting.MinimumSubscriptionDuration,
            StandardAnnonceMaxDuration = setting.StandardAnnonceMaxDuration,
            StandardDealsMaxDuration = setting.StandardDealsMaxDuration,
            StandardMaxMagasin = setting.StandardMaxMagasin,
            StandardAccountMaxAnnonces = setting.StandardAccountMaxAnnonces,
            StandardAccountMaxDeals = setting.StandardAccountMaxDeals,
            StandardAccountMaxProduts = setting.StandardAccountMaxProduts,
            ModeMagasinAndDeals = setting.ModeMagasinAndDeals,
            StandardAchatCommision = setting.StandardAchatCommision,
            StandardAccountMaxPoints = setting.StandardAccountMaxPoints,
            MinimumAddAnnoncePoints = setting.MinimumAddAnnoncePoints,
            MinimumAddDealsPoints = setting.MinimumAddDealsPoints,
            MinimumAddProductsPoints = setting.MinimumAddProductsPoints,
            CreationRatingPreviewForStandardAccount = setting.CreationRatingPreviewForStandardAccount,
            BoostAds = setting.BoostAds,
            UpgradeAccount = setting.UpgradeAccount,
            BuyPoints = setting.BuyPoints,
            PremiumAccount = setting.PremiumAccount,
            RatingPreview = setting.RatingPreview,
            NbDiamondAds = setting.NbDiamondAds,
            NbDiamondDeals = setting.NbDiamondDeals,
            NbDiamondProduct = setting.NbDiamondProduct
        };

        _context.Setting.Add(newSetting);
        await _context.SaveChangesAsync();

        return newSetting;
    }

    public async Task<int> GetNbDiamondAds()
    {
        var setting = await _context.Setting.FirstOrDefaultAsync();
        return setting?.NbDiamondAds ?? 0;
    }

    public async Task<int> GetNbDiamondDeals()
    {
        var setting = await _context.Setting.FirstOrDefaultAsync();
        return setting?.NbDiamondDeals ?? 0;
    }

    public async Task<int> GetNbDiamondProduct()
    {
        var setting = await _context.Setting.FirstOrDefaultAsync();
        return setting?.NbDiamondProduct ?? 0;
    }
}
