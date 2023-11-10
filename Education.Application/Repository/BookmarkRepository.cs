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

        public bool Add(BookMark bookMark)
        {
            _context.Add(bookMark);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(BookMark bookMark)
        {
            _context.Remove(bookMark);
            return _context.SaveChanges() > 0;
        }

        public async Task<BookMarkVM> GetbyId(string UserID)
        {
            var getP = await ( from p in _context.Playlists.Include(x => x.AppUser)
                               join b in _context.Bookmarks on p.Id equals b.PlaylistId
                               select p).ToListAsync();
            var GetBM = new BookMarkVM() { Playlists = getP };

            return GetBM;
                              
        }
    }
}
