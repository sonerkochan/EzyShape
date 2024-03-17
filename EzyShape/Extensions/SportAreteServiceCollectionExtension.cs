using EzyShape.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SportAreteServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();;

            return services;
        }
    }
}
