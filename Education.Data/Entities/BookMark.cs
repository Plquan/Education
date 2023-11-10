using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Entities
{
    public class BookMark
    {
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int PlaylistId { get; set; }  
        public Playlist Playlist { get; set; }
    }
}
