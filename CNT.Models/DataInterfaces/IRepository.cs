using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CNT.Models.DataInterfaces
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();
        IQueryable<T> All(params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);
        IQueryable<T> Filter(Expression<Func<T, bool>> filter, Expression<Func<T, object>> sortby, out int total, int index = 0, int size = 50);
        IQueryable<T> FilterNoException(Expression<Func<T, bool>> predicate);

        bool Contains(Expression<Func<T, bool>> predicate);
        T Find(params object[] keys);
        T Find(Expression<Func<T, bool>> predicate);
        T Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        T Create(T t);
        IQueryable<T> Create(IEnumerable<T> t);
        bool Delete(T t);
        bool Delete(Expression<Func<T, bool>> predicate);
        bool Update(T t);
        int Count { get; }
    }
}
