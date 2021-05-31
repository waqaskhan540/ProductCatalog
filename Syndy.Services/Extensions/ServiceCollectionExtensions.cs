using Microsoft.Extensions.DependencyInjection;
using Syndy.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Syndy.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
