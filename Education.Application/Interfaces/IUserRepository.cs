using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IUserRepository
    {
           
        Task<Like> GetLikes();
        Task<Comment> GetComments();
        Task<BookMark> GetBookMark();
        Task<UserVM> GetDetail();


    }
}
