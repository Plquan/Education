﻿using Education.Data.Entities;
using Education.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class ContentVM
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Video { get; set; }
        public string Thumb { get; set; }
        public int UserLike { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
