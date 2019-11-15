using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database2._0.Repositories
{
    public interface ICommonRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
        IEnumerable<T> Filter(Expression<Func<T, bool>> expression);

    }
}
