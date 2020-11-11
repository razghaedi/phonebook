using PhoneBook.Domain.Contracts.Comon;
using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Domain.Contracts.Phones
{
    public interface IPhoneRepository : IBaseRepository<Phone>
    {
    }
}
