using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VetPet.Data;
using VetPet.Models;

namespace VetPet.Repository
{
    public class BaseIDRepository<T> where T : BaseIDModel
    {
        protected ApplicationDbContext Db { get; private set; }
        protected readonly DbSet<T> DbSet;

        public BaseIDRepository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        protected virtual IQueryable<T> Query() => DbSet.AsQueryable();
        public virtual (List<T> list, int count) List(int? take = null, int? skip = null)
        {
            IQueryable<T> query = Query();

            int count = query.Count();

            query = query.OrderByDescending(c => c.Created);

            if (take.HasValue
                && skip.HasValue)
            {
                query = query.Skip(skip.Value).Take(take.Value);
            }

            return (query.ToList(), count);
        }

        public virtual T Get(int id) => DbSet.FirstOrDefault(c => c.ID == id);

        public virtual void Save() => Db.SaveChanges();

        private void Add(T item) => DbSet.Add(item);

        private void Remove(T entity) => DbSet.Remove(entity);

        public void Delete(T item)
        {
            Remove(item);
            Save();
        }

        public void Create(T item)
        {
            Add(item);
            Save();
        }
    }
}
