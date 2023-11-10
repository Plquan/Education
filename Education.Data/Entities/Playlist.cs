using Education.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public DateTime DateCreated { get; set; }
        public Status Status { get; set; }
        public AppUser AppUser { get; set; }
        public List<Content> Contents { get; set; }
        public List<BookMark> Bookmarks { get; set; }

    }
}
