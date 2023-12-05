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
    public class BookmarkRepository : IBookMarkRepository
    {
        private readonly EducationDbContext _context;
        public BookmarkRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(BookMark bookMark)
        {
            _context.Add(bookMark);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(string CurUserId, int PlaylistId)
        {
            var getb = await _context.Bookmarks.FirstOrDefaultAsync(b => b.UserId == CurUserId && b.PlaylistId == PlaylistId);
                _context.Remove(getb);
                 
            return await _context.SaveChangesAsync();
        }

        public async Task<BookMarkVM> GetbyId(string UserID)
        {
            var getP = await ( from p in _context.Playlists.Include(x => x.AppUser)
                               join b in _context.Bookmarks on p.Id equals b.PlaylistId
                               where b.UserId == UserID
                               select p).ToListAsync();
            var GetBM = new BookMarkVM() { Playlists = getP };

            return GetBM;
                              
        }
    }
}
