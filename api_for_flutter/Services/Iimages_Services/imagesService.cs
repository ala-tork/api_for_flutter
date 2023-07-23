using api_for_flutter.Data;
using api_for_flutter.Models.ImagesModel;
using api_for_flutter.Services.Images_Services;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.Iimages_Services
{
    public class imagesService : IImageService
    {
        protected readonly ApplicationDBContext _dbcontext;
        public imagesService(ApplicationDBContext dbcontext) {  _dbcontext = dbcontext; }




        public int SaveImages(IFormFile imageFile)
        {
            string imageUrl = SaveImageAndGetUrl(imageFile);
            var img = new Images
            {
                Title = imageUrl,
                //IdAds = AdsId,
                Active = 1,
            };
            _dbcontext.Images.Add(img);

            _dbcontext.SaveChanges();

            return img.IdImage;
        }


        public string SaveImageAndGetUrl(IFormFile imageFile)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            return "https://localhost:7058/Assets/images/" + uniqueFileName;
        }

        public Images UpdateImages(int idads,int idImages)
        {
            var img = _dbcontext.Images.FirstOrDefault(i=>i.IdImage == idImages);
            if (img != null)
            {
                img.IdAds = idads;
                _dbcontext.Entry(img).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return img;
            }
            else
                return null;
        }
    }
}
