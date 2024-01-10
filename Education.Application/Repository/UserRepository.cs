using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.Paging;
using Education.ViewModel.Users;
using Microsoft.AspNetCore.Http;
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
    
    public class UserRepository : IUserRepository
    {
        private readonly EducationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserRepository(EducationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<int> Add(AppUser appUser)
        {
            await _context.Users.AddAsync(appUser);
            return _context.SaveChanges();
        }

        public async Task<int> Delete(string Id)
        {
            var bookmark = await _context.Bookmarks.Where(u => u.UserId == Id).ToListAsync();
            _context.Bookmarks.RemoveRange(bookmark);
            var likes = await _context.Likes.Where(u => u.UserId == Id).ToListAsync();
            _context.Likes.RemoveRange(likes);
            var comments = await _context.Comments.Where(u => u.UserId == Id).ToListAsync();
            _context.Comments.RemoveRange(comments);

            var playlist = _context.Playlists
              .Include(x => x.Bookmarks)
           .Include(p => p.Contents)
               .ThenInclude(c => c.Comments)
           .Include(p => p.Contents)
               .ThenInclude(c => c.Likes)
           .FirstOrDefault(p => p.UserId == Id);

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
                _context.Playlists.Remove(playlist);
            }
            
            var getu = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Users.Remove(getu);
            return _context.SaveChanges();
        }

        public async Task<List<UserDetailVM>> GetAll()
        {
            var getall = await (from u in _context.Users join
                                   ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                select new UserDetailVM() {
                                    Id = u.Id,
                                    Name = u.UserName,
                                    Email = u.Email,
                                    Status = u.Status,
                                    Role = r.Name
                                }
                                ).ToListAsync();
            return getall;
        }

        public async Task<PagedResult<UserDetailVM>> GetAllUserPaging(int PageIndex, int PageSize)
        {
            var Id = _contextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var query = await (from u in _context.Users                     
                               where u.Id != Id
                               select new UserDetailVM()
                               {
                                   Id = u.Id,
                                   Name = u.UserName,
                                   Email = u.Email,
                                   Status = u.Status,
                               }
                                ).ToListAsync();
            int totalrow = query.Count();
            var data = query.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            var PagedResult = new PagedResult<UserDetailVM>()
            {
                TotalRecords = totalrow,
                Items = data,
                PageSize = PageSize,
                PageIndex = PageIndex
            };
            return PagedResult;
        }

        public async Task<EditUserVM> getbyId(string id)
        {
            var getuser = await (from u in _context.Users
                                 where u.Id == id
                                 select new EditUserVM()
                                 {
                                     Id = u.Id,
                                     Name = u.UserName,
                                     Email = u.Email,
                                     Image = u.Image,
                                 }
                                ).FirstOrDefaultAsync();

            return getuser;
        }

        public Task<EditAdminVM> getDetailAdmin(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(AppUser appUser)
        {
             _context.Users.Update(appUser);
            return _context.SaveChanges();
        }
    }
}
