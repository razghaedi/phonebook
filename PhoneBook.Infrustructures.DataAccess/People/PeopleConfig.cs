using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.People
{
    public class PeopleConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(500);
            builder.Property(p => p.Image).IsUnicode(false);
        }
    }
}
