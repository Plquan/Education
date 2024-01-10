using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel
{
    public class UpdateProfileVM
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public IFormFile? Image { get; set; }

    }
}
