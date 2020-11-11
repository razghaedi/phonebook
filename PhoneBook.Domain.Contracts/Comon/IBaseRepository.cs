using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Domain.Contracts.Comon
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity,new()
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        void Delete(int id);
    }
}
