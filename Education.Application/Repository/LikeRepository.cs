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

        public bool Delete(Like like)
        {
            _context.Remove(like);
            return _context.SaveChanges() > 0;
        }

        public async Task<List<Like>> GetAll()
        {
            var GetAll = await _context.Likes.ToListAsync();
            return GetAll;
        }

        public async Task<List<LikeVM>> GetbyId(string UserId)
        {
            var getLike = await (from c in _context.Contents.Include(x => x.Playlist).ThenInclude(x => x.AppUser)
                                 join l in _context.Likes on c.Id equals l.ContentId
                                 join u in _context.Users on l.UserId equals u.Id
                                 select new LikeVM()
                                 {
                                     AppUser = c.Playlist.AppUser,
                                     Contents = c
                                 }
                                 ).ToListAsync();
            

            return getLike;
        }
    }
}
