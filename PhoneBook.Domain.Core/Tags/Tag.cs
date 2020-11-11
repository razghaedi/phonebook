using PhoneBook.Domain.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Core.Tags
{
    public class Tag:BaseEntity
    {
        public string Title { get; set; }
        public List<PersonTag> People { get; set; }
    }
}
