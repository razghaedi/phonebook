using Microsoft.AspNetCore.Http;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models
{
    public abstract class PersonViewModels
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(300)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        //[FileExtensions(Extensions = ".png,.jpg,.jpeg,.gif", ErrorMessage = "Please upload an image file.")]
        public IFormFile Image { get; set; }

    }
    public class PersonForDisplayViewModels:PersonViewModels
    {
        public List<Tag> TagsForDisplay { get; set; }
    }
    public class PersonForGetViewModels:PersonViewModels
    {
        public List<int> SelectedTag { get; set; }
    }
}
