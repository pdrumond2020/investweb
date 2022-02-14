using Microsoft.Extensions.DependencyInjection;

namespace Invest.CrosCutting.Ioc.Resolvers
{
    public static class ServicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}