using DemoMongoDb.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace DemoMongoDb.Infrastructure.Persistence.Mappings;

public static class NewsClassMap
{
    public static void Register()
    {
        if (BsonClassMap.IsClassMapRegistered(typeof(News))) return;

        BsonClassMap.RegisterClassMap<News>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(x => x.Id)
              .SetIdGenerator(StringObjectIdGenerator.Instance)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.MapProperty(x => x.Title).SetElementName("title");
            cm.MapProperty(x => x.Slug).SetElementName("slug");
            cm.MapProperty(x => x.Content).SetElementName("content");
            cm.MapProperty(x => x.Summary).SetElementName("summary");
            cm.MapProperty(x => x.Thumbnail).SetElementName("thumbnail");
            cm.MapProperty(x => x.Author).SetElementName("author");
            cm.MapProperty(x => x.IsPublished).SetElementName("isPublished");
            cm.MapProperty(x => x.PublishedAt).SetElementName("publishedAt");
            cm.MapProperty(x => x.Tags).SetElementName("tags");
            cm.MapProperty(x => x.CreatedAt).SetElementName("createdAt");
            cm.MapProperty(x => x.UpdatedAt).SetElementName("updatedAt");

            cm.SetIgnoreExtraElements(true);
        });
    }
}