using DemoMongoDb.Domain.Entities;
using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.Persistence;
using DemoMongoDb.Infrastructure.Settings;

namespace DemoMongoDb.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(MongoDbContext context, MongoDbSettings settings) : base(context, settings.MenusCollectionName)
        {
        }
    }
}
