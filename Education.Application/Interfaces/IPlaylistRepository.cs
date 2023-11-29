using Education.Data.Entities;
using Education.ViewModel;
using Education.ViewModel.PlaylistViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<int> Add(Playlist playlist);
        Task<int> Update(Playlist playlistVM);
        Task<int> Delete(int PlaylistId);
        Task<List<PlaylistVM>> GetAll();
        Task<List<Playlist>> GetbyUserId(string UserId);
        Task<Playlist> GetbyId(int Id);
        Task<PlaylistDetailVM> GetContentById(int playlistId);
    }
}
