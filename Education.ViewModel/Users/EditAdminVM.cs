using Education.Data.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.ViewModel.Users
{
    public class EditAdminVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password do not match")]
        public string? ConfirmPassWord { get; set; }
    }
}
