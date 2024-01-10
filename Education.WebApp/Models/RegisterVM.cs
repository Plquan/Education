using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.WebApp.Models
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string Email { get; set; } 

        public string Profession { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
        public IFormFile Image { get; set;}
    }
}
