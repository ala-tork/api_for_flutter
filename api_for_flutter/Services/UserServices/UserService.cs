using api_for_flutter.Data;
using api_for_flutter.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserService (ApplicationDBContext dbContext , IConfiguration config)
        {
            _dbContext = dbContext;
            _configuration = config;
        }
        public string SaveImageAndGetUrl(IFormFile imageFile)
        {
            string uploadsFolder = _configuration["AssetsFolder:UsersFolder"].ToString();
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            uniqueFileName = uniqueFileName.Replace(" ", String.Empty);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }
            return uniqueFileName;
        }


        public async Task<User> AddUserImage(IFormFile img, int idUser)
        {
            var user = _dbContext.Users.Find(idUser);

            if (user == null)
            {
                return null;
            }

            var imgUrl = SaveImageAndGetUrl(img);
            user.ImageUrl = imgUrl;
            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
