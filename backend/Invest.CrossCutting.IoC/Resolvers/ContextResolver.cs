using Invest.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Invest.CrossCutting.IoC.Resolvers
{
    public static class ContextResolver
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddDbContext<InvestContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

            services.AddDbContext<InvestContext>(options =>
            {
                options.UseInMemoryDatabase("InvestDbInMemory");
            });

            services.AddScoped<InvestContext, InvestContext>();

            return services;
        }
    }
}