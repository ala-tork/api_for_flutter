using api_for_flutter.Data;
using api_for_flutter.Models.LikesPublicationModel;
using Microsoft.EntityFrameworkCore;

namespace api_for_flutter.Services.LikeServices
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDBContext _dbcontext;

        public LikeService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }




        public async  Task<Like> AddLike(CreateLikeModel createlike)
        {
            var l = new Like
            {
                IdAd = createlike.IdAd,
                IdDeal = createlike.IdDeal,
                IdProd=createlike.IdProd,
                IdUser = createlike.IdUser,
            };
            await _dbcontext.Likes.AddAsync(l);
            await  _dbcontext.SaveChangesAsync();
            return l;
        }

        public async Task<Like> DeleteLike(int IdLike)
        {
            var l = await _dbcontext.Likes.FirstOrDefaultAsync(l=>l.IdLP == IdLike);
             _dbcontext.Likes.Remove(l);
            await _dbcontext.SaveChangesAsync();
            return l;
        }

        public async Task<List<Like>?> GetLikeByAds()
        {
            var listLike = await _dbcontext.Likes.Where(l=>l.IdAd!=null).ToListAsync();
            if (listLike != null)
            {
                return listLike;
            }
            return null;
        }

        public async Task<List<Like>?> GetLikeByDeals()
        {
            var listLike = await _dbcontext.Likes.Where(l => l.IdDeal != null).ToListAsync();
            if (listLike != null)
            {
                return listLike;
            }
            return null;
        }

        public async Task<Like?> GetLikeById(int IdLike)
        {
            var l = await _dbcontext.Likes.FirstOrDefaultAsync(l => l.IdLP == IdLike);

            if (l!=null)
            {
                return l;
            }
            return null;
        }

        public async Task<List<Like>?> GetLikeByIdAd(int IdAd)
        {
            var l = await _dbcontext.Likes.Where(l => l.IdAd == IdAd).ToListAsync();
            if (l!=null)
            { return l; }
            return null;
        }

        public async  Task<List<Like>?> GetLikeByIdDeal(int IdDeal)
        {
            var l = await _dbcontext.Likes.Where(l => l.IdDeal == IdDeal).ToListAsync();
            if (l != null)
            { return l; }
            return null;
        }

        public async Task<Like?> GetLikeByIdUserIdAd(int Iduser,int idAd)
        {
            var l = await _dbcontext.Likes.FirstOrDefaultAsync(l=>l.IdUser == Iduser && l.IdAd==idAd);
            if (l != null)
            {
                return l;
            }
            return null;
        }

        public async  Task<Like?> GetLikeByIdUserIdDeal(int Iduser, int idDeal)
        {
            var l = await _dbcontext.Likes.FirstOrDefaultAsync(l => l.IdUser == Iduser && l.IdDeal == idDeal);
            if (l != null)
            {
                return l;
            }
            return null;
        }
    }
}
