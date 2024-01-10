using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.Contents;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Repository
{
    public class ContentRepository : IContentRepository
    {

        private readonly EducationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ContentRepository( EducationDbContext context,UserManager<AppUser> userManager) 
        {
               _context = context;
            _userManager = userManager;

        }
        public  Task<int> Add(Content content)
        {
             _context.Add(content);
            return _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var comments = await _context.Comments.Where(c => c.ContentId == Id).ToListAsync();
            _context.Comments.RemoveRange(comments);

            var likes = await _context.Likes.Where(c => c.ContentId == Id).ToListAsync();
            _context.Likes.RemoveRange(likes);

            var query = await _context.Contents.FirstOrDefaultAsync(x => x.Id == Id);  
            _context.Contents.Remove(query);
            return _context.SaveChanges();
        }

        public async Task<List<Content>> GetAll()
        {
           return await _context.Contents.ToListAsync();
        }

        public async Task<PlaylistDetailVM> GetAllByPlaylist(int PlaylistId)
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

        public async Task<Content> GetById(int id)
        {
           var getc = await _context.Contents.FirstOrDefaultAsync(x => x.Id == id);
            return getc;
        }

        public async Task<ContentVM> getContentDetail(int ContentId,string CuruserId)
        {
          
            var content = await _context.Contents.Include(x => x.Playlist).ThenInclude(x => x.AppUser)
                                .FirstOrDefaultAsync(x => x.Id == ContentId);       
            var LikeCount = await _context.Likes.Where(x => x.ContentId == ContentId).CountAsync();       
            var like = await _context.Likes.Where(i => i.ContentId == ContentId).ToListAsync();
            
            var Liked = await _context.Likes.CountAsync(x => x.UserId == CuruserId && x.ContentId == ContentId);
            var ListComment = await _context.Comments.Where(x => x.ContentId == ContentId).Include(x => x.AppUser).ToListAsync();
              
            var DetailContent = new ContentVM()
            {
                Id = ContentId,
                PlaylistId = content.PlaylistId,
                Title = content.Title,
                Description = content.Description,
                Video = content.Video,
                Thumb = content.Thumb,
                DateCreated = content.DateCreated,
                AppUser = content.Playlist.AppUser,            
                Likes = like,
                Comments = ListComment,               
                UserLike = Liked
               
            };
            return DetailContent;
        }

        public async Task<ContentDetail> ShowContentDetail(int ContentId)
        {
            var content = await _context.Contents.Include(x => x.Playlist).ThenInclude(x => x.AppUser)
                                 .FirstOrDefaultAsync(x => x.Id == ContentId);
            var LikeCount = await _context.Likes.Where(x => x.ContentId == ContentId).CountAsync();
       
            var ListComment = await _context.Comments.Where(x => x.ContentId == ContentId).Include(x => x.AppUser).ToListAsync();

            var DetailContent = new ContentDetail()
            {
                Id = ContentId,
                PlaylistId = content.PlaylistId,
                Title = content.Title,
                Description = content.Description,
                Video = content.Video,
                Thumb = content.Thumb,
                DateCreated = content.DateCreated,
                AppUser = content.Playlist.AppUser,
                CountLike = LikeCount,
                Comments = ListComment,             
            };
            return DetailContent;
        }

        public Task<int> Update(Content content)
        {
            _context.Update(content);
            return _context.SaveChangesAsync() ;
        }
    }
}
