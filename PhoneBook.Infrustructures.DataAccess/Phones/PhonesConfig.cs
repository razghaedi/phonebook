using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.Phones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Phones
{
    class PhonesConfig : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(p => p.PhoneNumber).HasMaxLength(20).IsRequired();
        }
    }
}
