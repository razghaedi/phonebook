using PhoneBook.Domain.Core.People;
using PhoneBook.Infrustructures.DataAccess.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.Mvc.Models
{
    public class PhoneViewModel
    {
        [Required]
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public bool IsInsertNewPhone { get; set; }
    }
}
