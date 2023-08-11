using api_for_flutter.Models.LikesPublicationModel;

namespace api_for_flutter.Services.LikeServices
{
    public interface ILikeService
    {
        Task<Like> AddLike(CreateLikeModel createlike);
        Task<Like> DeleteLike(int IdLike);
        Task<Like?> GetLikeById(int IdLike);
        Task<List<Like>?> GetLikeByIdDeal(int IdDeal);
        Task<List<Like>?> GetLikeByDeals();
        Task<List<Like>?> GetLikeByIdAd(int IdAd);
        Task<List<Like>?> GetLikeByAds();

        Task<Like?> GetLikeByIdUserIdAd(int Iduser,int idAd);
        Task<Like?> GetLikeByIdUserIdDeal(int Iduser, int idAd);


    }
}
