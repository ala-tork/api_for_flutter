﻿using api_for_flutter.Data;
using api_for_flutter.Models.AdsModels;
using api_for_flutter.Models.ImagesModel;
using api_for_flutter.Services.Images_Services;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.Iimages_Services
{
    public class imagesService : IImageService
    {
        protected readonly ApplicationDBContext _dbcontext;
        private readonly IConfiguration _configuration;
        public imagesService(ApplicationDBContext dbcontext , IConfiguration config) 
        { 
            _dbcontext = dbcontext;
            this._configuration = config;
        }




        public Images SaveImages(IFormFile imageFile)
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

            return img;
        }


        public string SaveImageAndGetUrl(IFormFile imageFile)
        {
            string uploadsFolder = _configuration["AssetsFolder:ImagesFolder"].ToString();
            //string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }

            // return "https://localhost:7058/Assets/images/" + uniqueFileName;
            return uniqueFileName;
        }

        public Images UpdateImages(int idads,int idImages)
        {
            var img = _dbcontext.Images.FirstOrDefault(i=>i.IdImage == idImages && i.Active==1);
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

        public Images DeleteImages(int idAds)
        {
            
            var imagesToDelete = _dbcontext.Images.Where(img => img.IdAds == idAds).ToList();

            if (imagesToDelete.Count > 0)
            {
                
                var imageToDelete = imagesToDelete[0];
                _dbcontext.Images.RemoveRange(imagesToDelete);
                _dbcontext.SaveChanges();
                return imageToDelete;
            }

            return null;
        }

        public List<Images> GetImagesByIdAds(int idAds)
        {
            var images = _dbcontext.Images.Where(img => img.IdAds == idAds && img.Active == 1).ToList();

            return images;
        }


        //Deals Images 

        public Images UpdateDealsImages(int idDeals, int idImages)
        {
            var img = _dbcontext.Images.FirstOrDefault(i => i.IdImage == idImages && i.Active == 1);
            if (img != null)
            {
                img.IdDeals = idDeals;
                _dbcontext.Entry(img).State = EntityState.Modified;
                _dbcontext.SaveChanges();
                return img;
            }
            else
                return null;
        }

        public Images DeleteDealsImages(int idDeals)
        {
            var imagesToDelete = _dbcontext.Images.Where(img => img.IdDeals == idDeals).ToList();

            if (imagesToDelete.Count > 0)
            {
                foreach(var img in imagesToDelete)
                {
                    string imagePath = Path.Combine(_configuration["AssetsFolder:ImagesFolder"].ToString(), img.Title);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }

                    _dbcontext.Images.RemoveRange(img);
                    _dbcontext.SaveChanges();
                    
                }

                return imagesToDelete[0];
            }

            return null;
        }

        public List<Images> GetImagesByIdDeals(int idDeals)
        {
            var images = _dbcontext.Images.Where(img => img.IdDeals == idDeals && img.Active == 1).ToList();
            return images;
        }


      /*  public void CleanUpOrphanedImages()
        {
            string imagesFolder = _configuration["AssetsFolder:ImagesFolder"].ToString();
            string[] imageFiles = Directory.GetFiles(imagesFolder);

            foreach (string imagePath in imageFiles)
            {
                string imageName = "/Assets/images/"+Path.GetFileName(imagePath);

                bool existsInDatabase = _dbcontext.Images.Any(img => img.Title == imageName);
                if (!existsInDatabase)
                {
                    File.Delete(imagePath);
                }
            }
        }*/
    }
}
