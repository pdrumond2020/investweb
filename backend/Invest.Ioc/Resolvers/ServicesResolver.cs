using Microsoft.Extensions.DependencyInjection;

namespace Invest.Ioc.Resolvers
{
    public static class ServicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}