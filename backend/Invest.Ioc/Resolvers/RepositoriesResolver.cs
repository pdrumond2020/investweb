using Microsoft.Extensions.DependencyInjection;

namespace Invest.Ioc.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}