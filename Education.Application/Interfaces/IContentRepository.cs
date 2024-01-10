using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IContentRepository
    {
        Task<int> Add(Content content);
        Task<int> Update(Content content);
        Task<int> Delete(int Id);
        Task<Content> GetById(int id);
        Task<ContentVM> getContentDetail(int ContentId, string userId);
        Task<ContentDetail> ShowContentDetail(int ContentId);
        Task<List<Content>> GetAll();
        Task<PlaylistDetailVM> GetAllByPlaylist(int playlistId);

    }
}
