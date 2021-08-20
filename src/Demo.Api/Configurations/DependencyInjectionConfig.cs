using Demo.Data;
using Demo.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<DemoContext>();
            services.AddScoped<CategoryRepository>();
        }
    }
}
