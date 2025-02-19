using System.Linq.Expressions;

namespace AncientCities.Domain.Common.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T?> GetByIdAsync(int id, string? includeProperties = null);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
