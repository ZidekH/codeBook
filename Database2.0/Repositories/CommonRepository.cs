using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database2._0.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;

        public CommonRepository(ApplicationDbContext context)
        {
            this._context = context;
            this.table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T item)
        {
            table.Add(item);
            Save();
        }

        public void Update(T item)
        {
            table.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            T itemToDelete = table.Find(id);
            table.Remove(itemToDelete);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> expression)
        {
          return table.Where(expression).ToList();
        }

    
    }
}
