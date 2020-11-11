using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models.AAA
{
    public class MyPasswordValidator : PasswordValidator<AppUser>
    {
        private readonly UserDbContext dbContext;

        public MyPasswordValidator(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public override Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            var parentResult = base.ValidateAsync(manager, user, password).Result;
            List<IdentityError> errors = new List<IdentityError>();
            if(!parentResult.Succeeded)
            {
                errors=parentResult.Errors.ToList();
            }
            if(dbContext.BadPasswords.Any(p=>p.Password==password))
            {
                errors.Add(new IdentityError
                {
                    Code = "BadPassword",
                    Description = "Password is Bad"
                });
            }
            return Task.FromResult(errors.Any() ?
                IdentityResult.Failed(errors.ToArray()) :
                IdentityResult.Success);
        }
    }
}
