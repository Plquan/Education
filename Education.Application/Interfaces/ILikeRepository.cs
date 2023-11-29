using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface ILikeRepository
    {
        bool Add(Like like);
        bool Delete(Like like);
        Task<List<LikeVM>> GetbyId(string UserId);
        Task<List<Like>> GetAll();
        Task <Like> GetContent(int ContentId, string UserId);
    }
}
