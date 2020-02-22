using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ip.oc6.dk
{
    public interface IStartup
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }

    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.None,
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(config =>
            {
                config.AllowAnyMethod();
                config.AllowAnyHeader();
                config.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
