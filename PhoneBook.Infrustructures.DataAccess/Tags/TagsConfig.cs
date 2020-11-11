using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain.Core.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Tags
{
    class TagsConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Title).HasMaxLength(50).IsRequired();
        }
    }
}

