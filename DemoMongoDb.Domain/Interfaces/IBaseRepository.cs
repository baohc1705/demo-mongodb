using System.Linq.Expressions;

namespace DemoMongoDb.Domain.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task UpdateAsync(Expression<Func<T, bool>> expression, T entity);
        Task DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
