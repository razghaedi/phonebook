using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class CreateUserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

    }
    public class CreateUserForDisplayViewModel:CreateUserViewModel
    {
        public List<AppRole> DisplayRoleName { get; set; }
    }
    public class CreateUserForSelectedViewModel : CreateUserViewModel
    {
        public List<string> SelectedRole { get; set; }
    }
}
