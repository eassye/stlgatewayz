using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Framework.Configuration;


namespace GatewayZ
{
    public class Startup
        {
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();
            //services.AddCaching();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".Gatewayz";
            });

            //var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            //    .AddEnvironmentVariables();
            //Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app)
            {
            app.UseSession();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            //app.UseMvc(config =>
            //{
            //    config.MapRoute(name: "Default",
            //                    template: "{controller}/{action}/{id?}",
            //                    defaults: new { controller = "App", Action = "Index" });
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });
        }
    }
}
