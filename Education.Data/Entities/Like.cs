using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Data.Entities
{
    public class Like
    {
        public string UserId { get; set; }        
        public int ContentId { get; set; }
        public AppUser AppUser { get; set; }
        public Content Content { get; set; }
    }
}
