using Microsoft.Extensions.DependencyInjection;

namespace Invest.CrosCutting.Ioc.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}