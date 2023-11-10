using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface ITutorRepository
    {
        Task<List<TutorVM>> GetAll();
        Task<TutorDetailVM> GetById(string Tutorid);
    }
}
