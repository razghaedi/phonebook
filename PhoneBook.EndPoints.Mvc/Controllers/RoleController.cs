using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.EndPoints.Mvc.Models.AAA;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles= roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppRole identityRole)
        {

            if(ModelState.IsValid)
            {
                var role = roleManager.FindByNameAsync(identityRole.Name).Result;
                if(role==null)
                {
                    var result = roleManager.CreateAsync(identityRole).Result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Exist Role Name in List Roless");
                return View(identityRole);
            }
            return View(identityRole);

            
        }
    }
}