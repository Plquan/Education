using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IBookMarkRepository
    {
        Task<int> Add(BookMark bookMark);
        Task<int> Remove(string CurUserId, int PlaylistId);
        Task<BookMarkVM> GetbyId(string UserID);
    }
}
