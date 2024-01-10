using Education.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel.Users
{
    public class UserDetailVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public string Role { get; set; }
    }
}
