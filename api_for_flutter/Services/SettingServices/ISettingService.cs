using api_for_flutter.Models.SettingModel;

namespace api_for_flutter.Services.SettingServices
{
    public interface ISettingService
    {
        public Task<Setting> CreateSetting(CreateSetting setting);
        public Task<int> GetNbDiamondDeals();
        public Task<int> GetNbDiamondAds();
        public Task<int> GetNbDiamondProduct();
    }
}
