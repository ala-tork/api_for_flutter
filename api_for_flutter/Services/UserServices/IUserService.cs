using api_for_flutter.Models.UserModel;

namespace api_for_flutter.Services.UserServices
{
    public interface IUserService
    {
        public Task<User> AddUserImage (IFormFile img, int idUser);
    }
}
