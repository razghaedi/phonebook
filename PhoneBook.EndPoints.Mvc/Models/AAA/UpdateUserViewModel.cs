using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class UpdateUserViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
    }
    public class UpdateUserForDisplayViewModel:UpdateUserViewModel
    {
        public List<AppRole> DisplayRoleName { get; set; }
    }
    public class UpdateUserForSelectedViewModel:UpdateUserViewModel
    {
        public List<string> SelectedRole { get; set; }
    }

}
