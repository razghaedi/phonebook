using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PhoneBook.Domain.Contracts.Pepole;
using PhoneBook.Domain.Contracts.PersonTags;
using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.EndPoints.Mvc.Models;

namespace PhoneBook.EndPoints.Mvc.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IPersonRepository personRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly IPersonTagRepository personTagRepository;

        public PeopleController
            (
                ITagRepository tagRepository,
                IPersonRepository personRepository,
                IPhoneRepository phoneRepository,
                IPersonTagRepository personTagRepository
            )
        {
            this.tagRepository = tagRepository;
            this.personRepository = personRepository;
            this.phoneRepository = phoneRepository;
            this.personTagRepository = personTagRepository;
        }
        public IActionResult Index()
        {
            
            return View(personRepository.GetAll().ToList());
        }
        public IActionResult Add()
        {
            PersonForDisplayViewModels model = new PersonForDisplayViewModels();
            model.TagsForDisplay = tagRepository.GetAll().ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(PersonForGetViewModels model)
        {
            if (!ModelState.IsValid)
            {
                PersonForDisplayViewModels personForDisplay = new PersonForDisplayViewModels()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    //TagsForDisplay = new List<Tag>(model.SelectedTag.Select(c => new Tag
                    //{
                    //    Id = c,
                    //    Title = tagRepository.GetById(c).Title
                    //}).ToList()),
                };
                personForDisplay.TagsForDisplay = tagRepository.GetAll().ToList();
                return View(personForDisplay);
            }
            Person person = new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                Tags = new List<PersonTag>(model.SelectedTag.Select(c => new PersonTag
                {
                    TagId = c,
                }).ToList())

            };
            if(model.Image?.Length>0)
            {
                string fileName = (personRepository.GetAll().Max(p => p.Id) + 1).ToString();
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                  "wwwroot",
                  "peopleImages",
                  fileName + Path.GetExtension(model.Image.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(stream);
                }
                person.Image=fileName+ Path.GetExtension(model.Image.FileName);
            }
            personRepository.Add(person);
            return RedirectToAction("Index");

        }

        public IActionResult Detail(int id)
        {
            var person = new Person();
            person = personRepository.GetById(id);
            var personDetail = new PersonDetailViewModel
            {
                PersonId=person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Address = person.Address,
                Image = person.Image,
                PersonTags = personTagRepository.GetAll()
                .Include(t => t.Tag).Where(t=>t.PersonId==id)
                .Select(s=> new Tag
                {
                    Id=s.Tag.Id,
                    Title=s.Tag.Title
                }).ToList(),
                Phones = phoneRepository.GetAll().Where(p => p.Person.Id == id).ToList()
            };
            
            return View(personDetail);
        }
    }
}