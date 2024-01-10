using Education.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel.Users
{
    public class EditUserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string? Role { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }
    }
}
