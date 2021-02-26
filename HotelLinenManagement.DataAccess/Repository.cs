using System;
using System.Collections.Generic;
using System.Linq;
using HotelLinenManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelLinenManagement.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly HotelLinenWarehouseContext context;
        private DbSet<T> entities;

        public Repository(HotelLinenWarehouseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}

