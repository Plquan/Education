using Education.Data.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Entities
{
    public class AppUser : IdentityUser
    {
        public string Image { get; set; }
        public Status Status { get; set; }
        public List<BookMark> BookMarks { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
