using api_for_flutter.Data;
using api_for_flutter.Models.WishListModel;
using Microsoft.EntityFrameworkCore;


namespace api_for_flutter.Services.WishListServices
{
    public class WishListService : IWishListService
    {
        private readonly ApplicationDBContext _dbcontext;

        public WishListService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<WishList> AddWishList(CreateWishList createWishList)
        {
            var newWishList = new WishList
            {
                IdUser = createWishList.IdUser,
                IdDeal = createWishList.IdDeal,
                IdProd = createWishList.IdProd,
                IdAd = createWishList.IdAd,
                MyDate = createWishList.MyDate
            };

            _dbcontext.WishList.Add(newWishList);
            await _dbcontext.SaveChangesAsync();

            return newWishList;
        }

        public async Task<WishList> DeleteWishList(int IdWishList)
        {
            var wishList = await _dbcontext.WishList.FindAsync(IdWishList);
            if (wishList == null)
                throw new Exception("WishList not found");

            _dbcontext.WishList.Remove(wishList);
            await _dbcontext.SaveChangesAsync();

            return wishList;
        }

        public async Task<WishList?> GetWishListById(int IdWishList)
        {
            var wishList = await _dbcontext.WishList.FindAsync(IdWishList);
            return wishList;
        }

        public async Task<List<WishList>>? GetWishListByIdUser(int Iduser, int page , int pageSize)
        {
            var res = await _dbcontext.WishList
                .Where(w => w.IdUser == Iduser)
                .Include(w => w.ads)
                .Include(w=>w.deals)
                .Include(w=>w.Product)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return res;
        }
        public int NbrAdsByIdUser(int iduser)
        {
            var res = _dbcontext.WishList.Where(a => a.IdUser == iduser).Count();
            return res;
        }

        public async Task<WishList?> GetWishListByIdUserIdAd(int Iduser, int idAd )
        {
            var wishList = await _dbcontext.WishList.FirstOrDefaultAsync(
                wl => wl.IdUser == Iduser && wl.IdAd == idAd
            );

            return wishList;
        }

        public async Task<WishList?> GetWishListByIdUserIdDeal(int Iduser, int idDeal)
        {
            var wishList = await _dbcontext.WishList.FirstOrDefaultAsync(
                wl => wl.IdUser == Iduser && wl.IdDeal == idDeal
            );

            return wishList;
        }

        public async Task<WishList?> GetWishListByIdUserIdProd(int Iduser, int idProd)
        {
            var wishList = await _dbcontext.WishList.FirstOrDefaultAsync(
                wl => wl.IdUser == Iduser && wl.IdProd == idProd
            );

            return wishList;
        }
    }
}
