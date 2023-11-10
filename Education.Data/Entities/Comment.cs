using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ContentId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public AppUser AppUser { get; set; }
        public Content Content { get; set; }
        
    }
}
