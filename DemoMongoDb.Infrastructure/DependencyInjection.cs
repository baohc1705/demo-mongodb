using DemoMongoDb.Application.Commons;
using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.MessageBroker;
using DemoMongoDb.Infrastructure.MessageBroker.Consumers;
using DemoMongoDb.Infrastructure.MessageBroker.Settings;
using DemoMongoDb.Infrastructure.Persistence;
using DemoMongoDb.Infrastructure.Persistence.Mappings;
using DemoMongoDb.Infrastructure.Repositories;
using DemoMongoDb.Infrastructure.Settings;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DemoMongoDb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            //Mongo DB
            MenuClassMap.Register();
            NewsClassMap.Register();


            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoSettings")
            );


            services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value
            );


            services.AddSingleton<MongoDbContext>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();

            // RabbitMQ + MassTransit
            var rabbitCfg = configuration
                .GetSection(nameof(RabbitMqSettings))
                .Get<RabbitMqSettings>()!;

            services.AddMassTransit(x =>
            {

                x.AddConsumer<MenuCreatedConsumer>();

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    
                    cfg.Host(rabbitCfg.Host, rabbitCfg.Port, "/", h =>
                    {
                        

                        h.Username(rabbitCfg.Username);
                        h.Password(rabbitCfg.Password);
                    });

                    cfg.ReceiveEndpoint("menu-created-queue",
                        e => e.ConfigureConsumer<MenuCreatedConsumer>(ctx));
                });
            });

            services.AddScoped<IEventBus, RabbitMqEventBus>();
            
            return services;

        }
    }
}
