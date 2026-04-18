namespace DemoMongoDb.Application.Commons
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event, CancellationToken ct = default) where T : class;
    }
}
