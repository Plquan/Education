using Education.Application.Interfaces;
using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly EducationDbContext _context;
        public CommentRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Comment comments)
        {
              _context.Add(comments);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == Id);
             _context.Remove(comment);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetAllCommentByTutor(string TutorId)
        {
            var Getall = await (from m in _context.Comments.Include(x => x.Content)
                                join c in _context.Contents on m.ContentId equals c.Id
                                join p in _context.Playlists on c.PlaylistId equals p.Id
                                where p.UserId == TutorId
                                select m
                ).ToListAsync();
            return Getall;
        }

        public async Task<List<UserCommentVM>> GetbyId(string UserId)
        {
             var getC = await ( from c in _context.Comments.Where(i => i.UserId == UserId)
                               select new UserCommentVM() { 
                                  Content = c.Content,
                                  Comment = c
                               }
                           ).ToListAsync();

            return getC;

        }

       

        public async Task<Comment> GetCommentbyId(int CommentId)
        {
            var getc = await  _context.Comments.FirstOrDefaultAsync(x => x.Id == CommentId);
            return getc;             
        }

     

        public async  Task<int> Update(Comment comments)
        {
               _context.Update(comments);      
            return await _context.SaveChangesAsync();
        }
    }
}
