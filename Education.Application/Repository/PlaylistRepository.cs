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
using Education.ViewModel.PlaylistViewModel;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Education.Application.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly EducationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public PlaylistRepository(EducationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public Task<int> Add(Playlist playlist)
        {
          _context.Add(playlist);
            return _context.SaveChangesAsync();
        }

        public  Task<int> Delete(int PlaylistId)
        {
            var playlist = _context.Playlists
              .Include(x => x.Bookmarks)
           .Include(p => p.Contents)
               .ThenInclude(c => c.Comments)
           .Include(p => p.Contents)
               .ThenInclude(c => c.Likes)
           .FirstOrDefault(p => p.Id == PlaylistId);

            if (playlist != null)
            {
                foreach (var item in playlist.Bookmarks)
                {
                    _context.Bookmarks.Remove(item);
                }

                foreach (var content in playlist.Contents)
                {
                    // Xóa comment
                    foreach (var comment in content.Comments)
                    {
                        _context.Comments.Remove(comment);
                    }

                    // Xóa like
                    foreach (var like in content.Likes)
                    {
                        _context.Likes.Remove(like);
                    }

                    // Xóa content
                    _context.Contents.Remove(content);
                }                                
            }
           
            // Xóa playlist       
            _context.Playlists.Remove(playlist);
            return _context.SaveChangesAsync();
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


        public async Task<int> Update(Playlist playlist)
        {
              
            _context.Update(playlist);
            return await _context.SaveChangesAsync();
        }

       public async Task<PlaylistDetailVM> getDetail(int PlaylistId)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var PlaylistDetail = await _context.Playlists.Include(x => x.AppUser).Where(i => i.Id == PlaylistId).FirstOrDefaultAsync();
            var PlaylistContent = await _context.Contents.Where(x => x.PlaylistId == PlaylistId).ToListAsync();
            var BoolmarkCount = await _context.Bookmarks.CountAsync(x => x.PlaylistId == PlaylistId && x.UserId == Id);

            var DetailPlaylist = new PlaylistDetailVM()
            {
                Id = PlaylistId,
                Title = PlaylistDetail.Title,
                Description = PlaylistDetail.Description,
                Thumb = PlaylistDetail.Thumb,
                DateCreated = PlaylistDetail.DateCreated,
                AppUser = PlaylistDetail.AppUser,
                Contents = PlaylistContent,
                IsBookMark = BoolmarkCount,
            };
            return DetailPlaylist;
        }

        public async Task<List<Playlist>> GetbyUserId(string UserId)
        {
            var GetP = await (from p in _context.Playlists.Where(x => x.UserId == UserId)
                               select new Playlist()
                               {
                                   Id = p.Id,
                                   Title = p.Title,
                                   Description = p.Description,
                                   Thumb= p.Thumb,
                                   DateCreated = p.DateCreated,
                                   Status = p.Status,
                                   Contents = p.Contents
                               }
                        ).ToListAsync();
            return GetP;
        }

        public async Task<Playlist> GetbyId(int Id)
        {
            var getp = await _context.Playlists.Include(x => x.Contents).FirstOrDefaultAsync(x => x.Id == Id);
            return getp;
        }
    }
}
