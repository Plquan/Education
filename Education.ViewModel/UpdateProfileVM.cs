using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class UpdateProfileVM
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassWord { get; set; }
        public IFormFile Image { get; set; }

    }
}
