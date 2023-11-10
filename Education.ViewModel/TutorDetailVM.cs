using Education.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class TutorDetailVM
    {
        public string UserId {  get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public int totalPlaylist { get; set; }
        public int totalVideo { get; set; }
        public int totalLike { get; set; }
        public int totalComment { get; set; }
       public List<Playlist> Playlists { get; set; }
        


    }
}
