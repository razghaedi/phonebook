using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Infrustructures.DataAccess.Common
{
    class PhoneBookContextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
    {
        public PhoneBookContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PhoneBookContext>();
            builder.UseSqlServer(@"Server=.\MSSQLSERVER2016;Database=PhoneBookDb;User Id=sa;Password=123");
            return new PhoneBookContext(builder.Options);

        }
    }
}
