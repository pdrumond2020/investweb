﻿using Invest.CrosCutting.Ioc.Resolvers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Invest.CrosCutting.Ioc
{
    public static class Ioc
    {
        public static IServiceCollection ResolveApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureContext(configuration)
                    .ConfigureServices()
                    .ConfigureRepositories()
                    .UseSwaggerConfiguration();

            return services;
        }
    }
}