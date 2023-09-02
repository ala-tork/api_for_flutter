using api_for_flutter.Models.ImagesModel;

namespace api_for_flutter.Services.Images_Services
{
    public interface IImageService
    {
        string SaveImageAndGetUrl(IFormFile imageFile);
        Images DeleteImages(int imageId);
        public Images SaveImages(IFormFile imageFile );
        public Images UpdateImages(int idads, int idImages);
        public Images DeleteAdsImages(int idAds);
        public List<Images> GetImagesByIdAds(int idAds);

        //Deals Images 
        public Images UpdateDealsImages(int idDeals, int idImages);
        public Images DeleteDealsImages(int idDeals);
        public List<Images> GetImagesByIdDeals(int idDeals);
        //public void CleanUpOrphanedImages();

        //prize
        public Task<Images> UpdateTaskImage(int idPrize, int idimage);
        public Task<Images> DeletePrizeImages(int idprize);
        public Task<Images> GetPrizeImage(int idprize);

        //Product Images 
        public Task<Images> UpdateProductImages(int idProduct, int idImages);
        public Images DeleteProductImages(int idProduct);
        public List<Images> GetImagesByIdProduct(int idProduct);
    }
}
