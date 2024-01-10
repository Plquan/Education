using Education.Data.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel.Contents
{
    public class EditContentVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PlaylistId { get; set; }
        public string Description { get; set; }
        public string UrlThumb { get; set; }
        public string UrlVideo { get; set; }
        public IFormFile? Video { get; set; }
        public IFormFile? Thumb { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
