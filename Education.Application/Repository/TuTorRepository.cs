using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Repository
{
    public class TuTorRepository : ITutorRepository
    {
        private readonly EducationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public TuTorRepository(EducationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<TutorVM>> GetAll()
        {
            //var GetTutor = await (from t in _context.Users
            //                      join p in _context.Playlists on t.Id equals p.UserId
            //                      join c in _context.Contents on p.Id equals c.PlaylistId
            //                      join l in _context.Likes on c.Id equals l.ContentId
            //                      select new TutorVM()
            //                      {
            //                          UserId = t.Id,
            //                          UserName = t.UserName,
            //                          UserImage = t.Image,
            //                          PlaylistCount = t.Playlists.Count,
            //                          LikeCount = t.Likes.Count,
            //                          VideoCount = p.Contents.Count,
            //                      }).Distinct().ToListAsync();
            //return GetTutor;


            var usersWithTotalContent = await (from u in _context.Users
                                               join p in _context.Playlists on u.Id equals p.UserId
                                               join c in _context.Contents on p.Id equals c.PlaylistId
                                               join l in _context.Likes on c.Id equals l.ContentId
                                               select new TutorVM()
                                               {
                                                   UserId = u.Id,
                                                   UserName = u.UserName,
                                                   UserImage = u.Image,
                                                   PlaylistCount = u.Playlists.Count,
                                                   LikeCount = p.Contents.SelectMany(c => c.Likes).Count(),
                                                   VideoCount = u.Playlists.SelectMany(playlist => playlist.Contents).Count()
                                               }).Distinct().ToListAsync();
            return usersWithTotalContent;
        }

        public async Task<TutorDetailVM> GetById(string Id)
        {
            var User = await _context.Users.FindAsync(Id);
          
            var GetTutorDetail = await _context.Playlists.Where(x => x.UserId == Id).ToListAsync();
            var toltaLikes = await (from l in _context.Likes
                                   join c in _context.Contents on l.ContentId equals c.Id
                                   join p in _context.Playlists on c.PlaylistId equals p.Id
                                   where p.UserId == Id
                                   select l
                                   ).ToListAsync();
            var totalVideos = await (from c in _context.Contents
                                   join p in _context.Playlists on c.PlaylistId equals p.Id
                                   where p.UserId == Id
                                   select c
                                   ).ToListAsync();              
            var totalComments = await (from m in _context.Comments
                                       join c in _context.Contents on m.ContentId equals c.Id
                                       join p in _context.Playlists on c.PlaylistId equals p.Id
                                       where p.UserId == Id
                                       select m
                                   ).ToListAsync();


            var DetailTuTorVM = new TutorDetailVM() { 
                 UserId = Id,
                 UserName = User.UserName,
                 UserImage = User.Image,
                 Playlists = GetTutorDetail,
                 totalPlaylist = GetTutorDetail.Count,      
                 totalLike = toltaLikes.Count,
                 totalVideo = totalVideos.Count,
                 totalComment = totalComments.Count,         
            };
            
            return DetailTuTorVM;


        }
    }
}
