namespace DemoMongoDb.Domain.Events
{
    public record MenuCreatedEvent(
        string Id,
        string Name,
        string? Url,
        int Order,
        bool IsActive,
        DateTime CreatedAt
    );
}
