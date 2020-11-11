using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Core.People
{
    public class PersonTag:BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
