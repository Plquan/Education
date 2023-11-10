using Education.Data.Entities;
using Education.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Interfaces
{
    public interface IPlaylistRepository
    {
        bool Add(Playlist playlist);
        bool Update(Playlist playlist);
        bool Delete(Playlist playlist);
        Task<List<PlaylistVM>> GetAll();
        Task<PlaylistDetailVM> GetContentById(int playlistId);
    }
}
