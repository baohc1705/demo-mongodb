using DemoMongoDb.Application.Commons;
using MassTransit;

namespace DemoMongoDb.Infrastructure.MessageBroker
{
    public class RabbitMqEventBus : IEventBus
    {
        private readonly IPublishEndpoint publishEndpoint;

        public RabbitMqEventBus(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task PublishAsync<T>(T @event, CancellationToken ct = default) where T : class
        {
            await publishEndpoint.Publish(@event, ct);
        }
    }
}
