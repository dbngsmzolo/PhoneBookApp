using PhoneBookApp.Core.Extensions;
using PhoneBookApp.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PhoneBookApp.Data;

namespace PhoneBookApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            
            services.AddSingleton(Configuration);

            services.AddSwaggerDocumentation();
            services.AddCorsForApp();
            services.AddJwt(Configuration);

            services.AddDependencyInjection();

            services.AddDbContext<EfDbContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:PhoneBookDBContext"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
                app.UseDeveloperExceptionPage();
            }

            app.UseCorsForApp();
            app.UseJwt();
        }
    }
}
