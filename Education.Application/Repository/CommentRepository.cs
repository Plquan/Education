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
    public class CommentRepository : ICommentRepository
    {
        private readonly EducationDbContext _context;
        public CommentRepository(EducationDbContext context)
        {
            _context = context;
        }

        public bool Add(Comment comments)
        {
            _context.Add(comments);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Comment comments)
        {
            _context.Remove(comments);
            return _context.SaveChanges() > 0;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetbyId(string UserId)
        {
             return await _context.Comments.Where(i => i.UserId == UserId).ToListAsync();
        }

        public bool Update(Comment comments)
        {
            _context.Update(comments);
            return _context.SaveChanges() > 0;
        }

        Task<List<Comment>> ICommentRepository.GetbyId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
