using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectDotNet.DAL.Repositories
{
    public class GenericRpository<T> : IRepository<T> where T: class
    {
        DbContext context;
        IDbSet<T> dbSet;
        public GenericRpository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void CreateOrUpdate(T entity)
        {
            dbSet.AddOrUpdate(entity);
            context.SaveChanges();
        }

        public T Get(int id) => dbSet.Find(id);

        public IEnumerable<T> GetAll() => dbSet;

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }


    }
}
