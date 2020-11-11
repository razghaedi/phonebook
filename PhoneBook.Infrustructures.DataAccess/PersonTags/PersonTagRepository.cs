using PhoneBook.Domain.Contracts.PersonTags;
using PhoneBook.Domain.Core.People;
using PhoneBook.Infrustructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.PersonTags
{
    public class PersonTagRepository : BaseRepository<PersonTag>, IPersonTagRepository
    {
        public PersonTagRepository(PhoneBookContext dbContext) : base(dbContext)
        {

        }
    }

}
