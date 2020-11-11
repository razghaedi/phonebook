using PhoneBook.Domain.Contracts.Pepole;
using PhoneBook.Domain.Core.People;
using PhoneBook.Infrustructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.People
{
    public class PersonRepository:BaseRepository<Person> ,IPersonRepository
    {
        public PersonRepository(PhoneBookContext dbContext):base(dbContext)
        {

        }
    }
}
