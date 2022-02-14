using Invest.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using Template.Data.Repositories;

namespace Invest.CrosCutting.Ioc.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}