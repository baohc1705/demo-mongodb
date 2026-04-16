using DemoMongoDb.Domain.Entities;
using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.Persistence;
using DemoMongoDb.Infrastructure.Settings;

namespace DemoMongoDb.Infrastructure.Repositories
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(MongoDbContext context, MongoDbSettings settings) : base(context, settings.NewsCollectionName)
        {
        }
    }
}
