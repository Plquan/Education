using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IContentRepository
    {
        bool Add(Content content);
        bool Update(Content content);
        bool Delete(Content content);
        Task<ContentVM> GetById(int ContentId, string userId);
        Task<List<Content>> GetAll();
        Task<PlaylistDetailVM> GetAllByPlaylist(int playlistId);

    }
}
