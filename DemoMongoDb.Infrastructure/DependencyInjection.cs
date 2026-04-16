using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.Persistence;
using DemoMongoDb.Infrastructure.Persistence.Mappings;
using DemoMongoDb.Infrastructure.Repositories;
using DemoMongoDb.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMongoDb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            // Register BsonClassMaps
            MenuClassMap.Register();

            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoSettings")
            );

            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            

            return services;
        }
    }
}
