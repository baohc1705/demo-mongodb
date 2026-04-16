using DemoMongoDb.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace DemoMongoDb.Infrastructure.Persistence.Mappings;

public static class MenuClassMap
{
    public static void Register()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(Menu))) return;

        BsonClassMap.RegisterClassMap<Menu>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(x => x.Id)
              .SetIdGenerator(StringObjectIdGenerator.Instance)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.MapProperty(x => x.Name).SetElementName("name");
            cm.MapProperty(x => x.Description).SetElementName("description");
            cm.MapProperty(x => x.Url).SetElementName("url");
            cm.MapProperty(x => x.Order).SetElementName("order");
            cm.MapProperty(x => x.IsActive).SetElementName("isActive");
            cm.MapProperty(x => x.CreatedAt).SetElementName("createdAt");
            cm.MapProperty(x => x.UpdatedAt).SetElementName("updatedAt");

            cm.SetIgnoreExtraElements(true);
        });
    }
}