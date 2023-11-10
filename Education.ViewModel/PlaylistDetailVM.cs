using Education.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class PlaylistDetailVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumb { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }
        public List<Content> Contents { get; set; }
    }
}
