using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syndy.Data.Context;
using Syndy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<SyndyDataContext>(options => 
                        options.UseSqlServer(connectionString, config => config.MigrationsAssembly(typeof(SyndyDataContext).Assembly.FullName)));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
