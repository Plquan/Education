using Education.Data.Entities;
using Education.Data.Enum;

namespace Education.ViewModel
{
    public class PlaylistVM
    {
        public int Id { get; set; }    
        public string Title { get; set; }
        public string Thumb { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }
    }
}
