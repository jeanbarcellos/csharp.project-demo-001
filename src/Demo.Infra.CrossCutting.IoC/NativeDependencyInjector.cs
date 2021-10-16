using Demo.Application.Interfaces;
using Demo.Application.Services;
using Demo.Data;
using Demo.Data.Repositories;
using Demo.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infra.CrossCutting.IoC
{
    public class NativeDependencyInjector
    {
        // Application
        public static void RegisterServices(IServiceCollection services)
        {
            // Core

            // Application
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            // Data
            services.AddScoped<DemoContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
