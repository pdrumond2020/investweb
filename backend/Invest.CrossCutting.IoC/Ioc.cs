using AutoMapper;
using Invest.CrosCutting.Ioc.Resolvers;
using Invest.CrossCutting.Auth.Models;
using Invest.CrossCutting.IoC.AutoMapper;
using Invest.CrossCutting.IoC.Resolvers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Invest.CrossCutting.IoC
{
    public static class Ioc
    {
        public static IServiceCollection ResolveApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureContext(configuration)
                    .ConfigureServices()
                    .ConfigureRepositories()
                    .UseSwaggerConfiguration()
                    .ConfigureAutoMapper();

            return services;
        }
    }
}