using PhoneBook.Domain.Contracts.Comon;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneBook.Infrustructures.DataAccess.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity:BaseEntity,new()         
    {
        private readonly PhoneBookContext _context;
        public BaseRepository(PhoneBookContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entity = new TEntity
            {
                Id = id
            };
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
