using api_for_flutter.Models.ImagesModel;

namespace api_for_flutter.Services.Images_Services
{
    public interface IImageService
    {
        string SaveImageAndGetUrl(IFormFile imageFile);
        public int SaveImages(IFormFile imageFile );
        public Images UpdateImages(int idads, int idImages);
    }
}
