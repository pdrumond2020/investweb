using AutoMapper;
using Invest.CrossCutting.IoC.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Invest.CrossCutting.IoC.Resolvers
{
    public static class AutoMapperResolver
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton(provider => new MapperConfiguration(config =>
            {
                config.ForAllMaps((typeMap, map) => map.ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                {
                    if (srcMember is DateTime dateTime)
                        return dateTime != DateTime.MinValue;
                    return srcMember != null;
                })));

                config.AddProfile(profile: ActivatorUtilities.GetServiceOrCreateInstance<AutoMapperSetup>(provider));
            }).CreateMapper());

            return services;
        }
    }
}