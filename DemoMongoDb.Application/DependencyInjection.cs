using DemoMongoDb.Application.Commons.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoMongoDb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(ApplicationMappingProfile));
            });

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
