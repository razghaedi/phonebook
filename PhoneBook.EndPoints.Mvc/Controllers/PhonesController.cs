using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Contracts.Pepole;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.EndPoints.Mvc.Models;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    public class PhonesController : Controller
    {
        private readonly IPhoneRepository phoneRepository;
        private readonly IPersonRepository personRepository;

        public PhonesController(IPhoneRepository phoneRepository,IPersonRepository personRepository)
        {
            this.phoneRepository = phoneRepository;
            this.personRepository = personRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(int id)
        {
            PhoneViewModel model = new PhoneViewModel()
            {
                PersonId =id,
                PhoneNumber = "",
                IsInsertNewPhone = false
            };
            model.PersonId =id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Add (PhoneViewModel model)
        {
            if(ModelState.IsValid)
            {
                Phone phone = new Phone()
                {
                    PhoneNumber = model.PhoneNumber,
                    Person = personRepository.GetById(model.PersonId)

                };
                phoneRepository.Add(phone);
                PhoneViewModel modelForDisplay = new PhoneViewModel()
                {
                    PersonId = model.PersonId,
                    PhoneNumber = "",
                    IsInsertNewPhone = true
                };
                return View("Add", modelForDisplay);
            }
            return View(model);
        }
        public IActionResult Delete(int id,int personId)
        {          
            if (id > 0)
            {
                phoneRepository.Delete(id);
            }

            return RedirectToAction("Detail","People", new { id = personId });
        }
    }
}