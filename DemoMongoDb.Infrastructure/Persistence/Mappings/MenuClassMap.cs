using DemoMongoDb.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace DemoMongoDb.Infrastructure.Persistence.Mappings
{
    public static class MenuClassMap
    {
        public static void Register()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Menu))) return;

            BsonClassMap.RegisterClassMap<Menu>(m =>
            {
                m.AutoMap();

                m.MapIdProperty(x => x.Id)
                 .SetIdGenerator(StringObjectIdGenerator.Instance)
                 .SetSerializer(new StringSerializer(BsonType.ObjectId));

                m.MapProperty(x => x.Name).SetElementName("name");
                m.MapProperty(x => x.Description).SetElementName("description");
                m.MapProperty(x => x.Url).SetElementName("url");
                m.MapProperty(x => x.Order).SetElementName("order");
                m.MapProperty(x => x.IsActive).SetElementName("isActive");
                m.MapProperty(x => x.CreatedAt).SetElementName("createdAt");
                m.MapProperty(x => x.UpdatedAt).SetElementName("updatedAt");

                m.SetIgnoreExtraElements(true);
            });
        }
    }
}
