using DemoMongoDb.Infrastructure.Settings;
using MongoDB.Driver;

namespace DemoMongoDb.Infrastructure.Persistence
{
    public class MongoDbContext 
    {
        private readonly IMongoDatabase database;
        public MongoDbContext(MongoDbSettings settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) =>
            database.GetCollection<T>(name);
    }
}
