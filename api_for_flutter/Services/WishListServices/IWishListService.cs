using api_for_flutter.Models.LikesPublicationModel;
using api_for_flutter.Models.WishListModel;

namespace api_for_flutter.Services.WishListServices
{
    public interface IWishListService
    {
        Task<WishList> AddWishList(CreateWishList createWishList);
        Task<WishList> DeleteWishList(int IdWishList);
        Task<WishList?> GetWishListById(int IdWishList);
        Task<List<WishList>>? GetWishListByIdUser(int Iduser, int page , int pageSize);
        int NbrAdsByIdUser(int iduser);
        Task<WishList?> GetWishListByIdUserIdAd(int Iduser, int idAd);
        Task<WishList?> GetWishListByIdUserIdDeal(int Iduser, int idDeal);
        Task<WishList?> GetWishListByIdUserIdProd(int Iduser, int idProd);
    }
}
