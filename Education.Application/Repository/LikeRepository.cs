using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private readonly EducationDbContext _context;
        public LikeRepository(EducationDbContext context)
        {
            _context = context;
        }
        public bool Add(Like like)
        {
            _context.Add(like);
            return _context.SaveChanges() > 0;
        }

        public  bool Delete(Like like)
        {
             _context.Remove(like);      
            return _context.SaveChanges() > 0;
        }


        public async Task<List<Like>> GetAll()
        {
            var GetAll = await _context.Likes.ToListAsync();
            return GetAll;
        }

        public async Task<List<LikeVM>> GetbyId(string Id)
        {
            var getlike = await (from l in _context.Likes.Where(l => l.UserId == Id)
                                 select new LikeVM()
                                 {
                                     AppUser = l.Content.Playlist.AppUser,
                                     Contents = l.Content

                                 }
                ).ToListAsync();

            return getlike;
        }

        public async Task<Like> GetContent(int ContentId, string UserId)
        {
            var GetContent = await _context.Likes.FirstOrDefaultAsync(x => x.ContentId == ContentId && x.UserId == UserId);    
            return GetContent;
        }
    }
}
