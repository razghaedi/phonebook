using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class MyLoginModel
    {
        [Required]
        [Display (Name="User Name Or Email")]
        public string Name { get; set; }
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
