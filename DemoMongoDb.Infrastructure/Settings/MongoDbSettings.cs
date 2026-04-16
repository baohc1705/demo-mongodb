namespace DemoMongoDb.Infrastructure.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
        public string MenusCollectionName { get; set; } = "menus";
        public string NewsCollectionName { get; set; } = "news";
    }
}
