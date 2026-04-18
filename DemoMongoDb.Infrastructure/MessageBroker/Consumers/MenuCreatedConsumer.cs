using DemoMongoDb.Domain.Events;
using DnsClient.Internal;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace DemoMongoDb.Infrastructure.MessageBroker.Consumers
{
    public class MenuCreatedConsumer : IConsumer<MenuCreatedEvent>
    {
        private readonly ILogger<MenuCreatedConsumer> logger;

        public MenuCreatedConsumer(ILogger<MenuCreatedConsumer> logger)
        {
            this.logger = logger;
        }

        public async Task Consume(ConsumeContext<MenuCreatedEvent> context)
        {
            var e = context.Message;
            //logger.LogInformation("[MenuCreated] Id={Id} Name={Name} IsActive={IsActive} at {At}",
            //e.Id, e.Name, e.IsActive, e.CreatedAt);
            logger.LogInformation("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            logger.LogInformation("📨 [RabbitMQ] MenuCreatedEvent nhận được!");
            logger.LogInformation("   MessageId  : {MsgId}", context.MessageId);
            logger.LogInformation("   CorrelationId: {CorrId}", context.CorrelationId);
            logger.LogInformation("   Queue      : {Queue}", context.ReceiveContext.InputAddress);
            logger.LogInformation("   ── Payload ────────────────────────");
            logger.LogInformation("   Id         : {Id}", e.Id);
            logger.LogInformation("   Name       : {Name}", e.Name);
            logger.LogInformation("   Url        : {Url}", e.Url);
            logger.LogInformation("   Order      : {Order}", e.Order);
            logger.LogInformation("   IsActive   : {IsActive}", e.IsActive);
            logger.LogInformation("   CreatedAt  : {CreatedAt}", e.CreatedAt);
            logger.LogInformation("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            // TODO: gửi email, invalidate cache, sync Elasticsearch...
            // Giả lập xử lý side-effect mất 500ms
            await Task.Delay(500, context.CancellationToken);

            logger.LogInformation("✅ [RabbitMQ] MenuCreatedEvent xử lý xong!");
        }
    }
}
