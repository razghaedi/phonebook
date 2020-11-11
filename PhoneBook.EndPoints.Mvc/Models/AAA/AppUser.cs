using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class AppUser:IdentityUser<int>
    {
        public string firstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BrithDate { get; set; }
        public ICollection<AppUserRoles> UserRoles { get; set; }

    }
}
