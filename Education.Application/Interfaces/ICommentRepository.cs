using Education.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface ICommentRepository
    {
        bool Add(Comment comments);
        bool Update(Comment comments);
        bool Delete(Comment comments);
        Task<List<Comment>> GetbyId(string userId);
        Task<List<Comment>> GetAll();

    }
}
