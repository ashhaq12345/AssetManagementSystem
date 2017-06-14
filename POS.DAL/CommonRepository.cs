using POS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.DAL
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        protected DbContext db;

        public DbSet<T> Table
        {
            get
            {
                return db.Set<T>();
            }
        }

        public CommonRepository(DbContext dbContext)
        {
            db = dbContext;
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }

        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(long id)
        {
            T entity = Table.Find(id);
            return entity;
        }

        public bool Remove(T entity)
        {
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            Table.AddOrUpdate(entity);
            return db.SaveChanges() > 0;
        }

        public bool Add(ICollection<T> entities)
        {
            Table.AddRange(entities);
            return db.SaveChanges() > 0;
        }

        public bool Update(ICollection<T> entities)
        {
            Table.AddOrUpdate(entities.ToArray());
            return db.SaveChanges() > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
