using AutoMapper;
using DotNetApi.Domain.Commands.User;
using DotNetApi.Domain.Interfaces.Repositories;
using DotNetApi.Domain.Profiles.Entities;
using DotNetApi.Domain.Queries.User;
using DotNetApi.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Reflection;

namespace DotNetApi.Infrastructure.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AddUserCommand), typeof(GetAllUserQuery));
            
            services.AddRepositories();

            services.AddSerilogServices(configuration);

            services.AddAutoMapperConfig();

            return services;
        }

        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(UserProfile));
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services.AddSingleton<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddSerilogServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            var loggerConfiguration = new LoggerConfiguration();

            Log.Logger = loggerConfiguration.CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
            return services.AddSingleton(Log.Logger);
        }
    }
}
