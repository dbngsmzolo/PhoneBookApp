using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBookApp.Core.Extensions
{
    public static class CorsServiceExtension
    {
        private static readonly string PhoneBookAppOrigins = "_PhoneBookAppUiOrigins";

        public static IServiceCollection AddCorsForApp(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddCors(options =>
            {
                options.AddPolicy(PhoneBookAppOrigins,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IApplicationBuilder UseCorsForApp(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(PhoneBookAppOrigins);
            app.UseAuthorization(); //must appear here in order for Authorization to work
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            return app;
        }
    }
}
