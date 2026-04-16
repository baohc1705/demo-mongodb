using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.Persistence;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DemoMongoDb.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> collection;
        public BaseRepository(MongoDbContext context, string collectionName)
        {
            collection = context.GetCollection<T>(collectionName);
        }

        public async Task CreateAsync(T entity)
        {
            await collection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> expression)
        {
            await collection.DeleteOneAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await collection.Find(expression).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Expression<Func<T, bool>> expression, T entity)
        {
            await collection.ReplaceOneAsync(expression, entity);
        }
    }
}
