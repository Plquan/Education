using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class EditCommentVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ContentId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
