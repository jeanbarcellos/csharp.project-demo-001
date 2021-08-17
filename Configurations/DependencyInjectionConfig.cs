using Microsoft.Extensions.DependencyInjection;
using System;

namespace Demo.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


        }
    }
}
