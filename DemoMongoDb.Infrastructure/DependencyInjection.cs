using DemoMongoDb.Domain.Interfaces;
using DemoMongoDb.Infrastructure.Persistence;
using DemoMongoDb.Infrastructure.Persistence.Mappings;
using DemoMongoDb.Infrastructure.Repositories;
using DemoMongoDb.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DemoMongoDb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
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
            return services;

        }
    }
}
