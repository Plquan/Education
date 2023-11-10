using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;

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
        public bool Add(Content content)
        {
            _context.Add(content);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Content content)
        {
             _context.Remove(content);
            return _context.SaveChanges() > 0;
        }

        public async Task<ContentVM> GetById(int ContentId,string userId)
        {
            var content = await _context.Contents.Include(x => x.Playlist).ThenInclude(x => x.AppUser)
                                .FirstOrDefaultAsync(x => x.Id == ContentId);
            var listComment = await _context.Comments.Include(x => x.AppUser).Where(x => x.Id == ContentId).ToListAsync();
            var LikeCount = await _context.Likes.Where(x => x.ContentId == ContentId).CountAsync();       
            var currentlike = await _context.Likes.Where(i => i.ContentId == ContentId).ToListAsync();
            
            var Liked = await _context.Likes.CountAsync(x => x.UserId == userId && x.ContentId == ContentId);

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
                Comments = listComment,
                Likes = currentlike,
                UserLiked = Liked
            };
            return DetailContent;
        }

        public bool Update(Content content)
        {
            _context.Update(content);
            return _context.SaveChanges() > 0;
        }
    }
}
