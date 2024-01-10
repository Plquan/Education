using Education.Data.EF;
using Education.Data.Entities;
using Education.ViewModel.Paging;
using Education.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
     
    public interface IUserRepository
    {
        Task<int> Add(AppUser appUser);
        Task<int> Update(AppUser appUser);
        Task<int> Delete(string Id);
        Task<List<UserDetailVM>> GetAll();
        Task<EditUserVM> getbyId(string id);
        Task<PagedResult<UserDetailVM>> GetAllUserPaging(int PageIndex,int PageSize);
        Task<PagedResult<UserDetailVM>> GetAllTeacherPaging(int PageIndex, int PageSize);
        Task<EditAdminVM> getDetailAdmin(string id);
    }
}
