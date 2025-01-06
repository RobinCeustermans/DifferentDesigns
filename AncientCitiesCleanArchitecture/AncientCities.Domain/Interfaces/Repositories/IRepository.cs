using System.Linq.Expressions;

namespace AncientCities.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
