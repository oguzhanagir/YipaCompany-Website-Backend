using System.Linq.Expressions;

namespace Yipa.Core.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        List<T> List(Expression<Func<T, bool>> where);
        T? Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
    }
}
