using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Core.People;
using PhoneBook.Domain.Core.Phones;
using PhoneBook.Domain.Core.Tags;
using PhoneBook.Infrustructures.DataAccess.People;
using PhoneBook.Infrustructures.DataAccess.Phones;
using PhoneBook.Infrustructures.DataAccess.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Common
{
    public class PhoneBookContext:DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new PeopleConfig());
            modelBuilder.ApplyConfiguration(new PhonesConfig());
            modelBuilder.ApplyConfiguration(new TagsConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonTag> personTags { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
