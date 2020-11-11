using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhoneBook.EndPoints.Mvc.Models.AAA;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public UserController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var users = userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            CreateUserForDisplayViewModel roles = new CreateUserForDisplayViewModel
            {
                DisplayRoleName=roleManager.Roles.ToList()
            };
            return View(roles);
        }
        [HttpPost]
        public IActionResult Create(CreateUserForSelectedViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser()
                { 
                    UserName=model.UserName,
                    Email=model.Email,
                };
                var result = userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    foreach (var item in model.SelectedRole)
                    {
                        var role = roleManager.FindByIdAsync(item).Result;
                        var resultAddRole = userManager.AddToRoleAsync(user,role.Name).Result;
                    }
                    

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }

            }
            return View(model);
        }

        public IActionResult Update(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                UpdateUserForDisplayViewModel model = new UpdateUserForDisplayViewModel()
                {
                    Email = user.Email,
                    DisplayRoleName = roleManager.Roles.ToList()
                    
                };
                return View(model);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Update(string id,UpdateUserViewModel model)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    user.Email = model.Email;
                    var result = userManager.UpdateAsync(user).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.Code, item.Description);
                        }
                    }
                }
                return View(model);
            }
            return NotFound();

        }
        public IActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if(user!=null)
            {
                var result= userManager.DeleteAsync(user).Result;
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                }
            }
            return NotFound();
        }

        public IActionResult AddToRoleAdmin(string id,string roleName)
        {
            var user = userManager.FindByIdAsync(id).Result;
            if (!string.IsNullOrEmpty(roleName) && user!=null)
            {
                var result = userManager.AddToRoleAsync(user, roleName).Result;
            }
            return RedirectToAction("Index");
        }
    }
}