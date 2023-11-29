using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<int> Add(Comment comments);
        Task<int> Update(Comment comments);
        Task<int> Delete(int Id);
        Task<List<UserCommentVM>> GetbyId(string CuruserId);
        Task<List<Comment>> GetAll();
        Task<Comment> GetCommentbyId(int CommentId);
        Task<List<Comment>> GetAllCommentByTutor(string TutorId);

    }
}
