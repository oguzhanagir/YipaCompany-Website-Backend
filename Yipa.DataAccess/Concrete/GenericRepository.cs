using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Yipa.Core.Abstract;

namespace Yipa.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected YipaDbContext _dbContext;
        private readonly ILogger _logger;
        internal DbSet<T> _dbset;

        public GenericRepository(YipaDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dbset = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbset.AddRange(entities);
        }

        public T? Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbset.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id)!;
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
    }
}
