using Education.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class CommentVM
    {
        public int ContentId { get; set; }
        public string Message { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
