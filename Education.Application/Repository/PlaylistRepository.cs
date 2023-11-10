using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Education.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.ViewModel;

namespace Education.Application.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly EducationDbContext _context;
        public PlaylistRepository(EducationDbContext context)
        {
            _context = context;
        }
        public bool Add(Playlist playlist)
        {
          _context.Add(playlist);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Playlist playlist)
        {
            _context.Remove(playlist);
            return _context.SaveChanges() > 0;
        }

        public async Task<List<PlaylistVM>> GetAll()
        {
            var Getplaylist = await (from p in _context.Playlists.Include(x => x.AppUser)                            
                               select new PlaylistVM()
                               {
                                   Id = p.Id,
                                   Title = p.Title,
                                   Thumb = p.Thumb,
                                   DateCreated = p.DateCreated,
                                   AppUser = p.AppUser,
                               }).ToListAsync();
            return Getplaylist;
        }

       
        public bool Update(Playlist playlist)
        {
            _context.Update(playlist);
            return _context.SaveChanges() > 0;
        }

       public async Task<PlaylistDetailVM> GetContentById(int PlaylistId)
        {
            var PlaylistDetail = await _context.Playlists.Include(x => x.AppUser).Where(i => i.Id == PlaylistId).FirstOrDefaultAsync();
            var PlaylistContent = await _context.Contents.Where(x => x.PlaylistId == PlaylistId).ToListAsync();

            var DetailPlaylist = new PlaylistDetailVM()
            {
                Id = PlaylistId,
                Title = PlaylistDetail.Title,
                Description = PlaylistDetail.Description,
                Thumb = PlaylistDetail.Thumb,
                DateCreated = PlaylistDetail.DateCreated,
                AppUser = PlaylistDetail.AppUser,
                Contents = PlaylistContent,         
            };
            return DetailPlaylist;
        }

  
    }
}
