using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Services;
using WebApplication.Domain.Settings;
using WebApplication.Infra.Database;
using WebApplication.Infra.Interfaces.Repositories;
using WebApplication.Infra.Migrations;
using WebApplication.Infra.Repositories;

namespace WebApplication.Infra.IoC
{
    public static class Resolver
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            DbConnectionSettings dbConnection = configuration.GetSection("DbConnectionSettings").Get<DbConnectionSettings>();

            var connectionString = $"Data Source={dbConnection.Server}; Initial Catalog={dbConnection.Database}; User ID={dbConnection.User}; Password={dbConnection.Password};";

            var connectionFactory = new SqlConnectionFactory(connectionString);

            services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(MigrationsAssembly).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());

            services.AddSingleton(connectionFactory);

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);

            return services;
        }
    }
}
