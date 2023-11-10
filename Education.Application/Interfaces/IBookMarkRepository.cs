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
        bool Add(BookMark bookMark);
        bool Delete(BookMark bookMark);
        Task<BookMarkVM> GetbyId(string UserID);
    }
}
