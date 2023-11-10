using Education.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class TutorVM
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public int PlaylistCount { get; set; }
        public int LikeCount { get; set; }
        public int VideoCount { get; set; }
    }
}
