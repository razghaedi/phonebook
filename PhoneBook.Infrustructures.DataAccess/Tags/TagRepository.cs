using PhoneBook.Domain.Contracts.Tags;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrustructures.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Tags
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(PhoneBookContext dbContext):base(dbContext)
        {
           
        }
    }
}
