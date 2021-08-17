using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Configurations
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services)
        {

        }

        public static void UseCorsSetup(this IApplicationBuilder app)
        {
            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.SetIsOriginAllowed(origin => true);
                x.AllowCredentials();
            });
        }
    }
}
