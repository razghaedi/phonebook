using PhoneBook.Domain.Contracts.Phones;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Infrustructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Phones
{
    public class PhoneRepository:BaseRepository<Phone>,IPhoneRepository
    {
        public PhoneRepository(PhoneBookContext dbContext):base(dbContext)
        {

        }
    }
}
