using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace GatewayZ
{
    public class Startup
        {
        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {   
            services.AddMvc();
            //services.AddCaching();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".Gatewayz";
            });
        }
            public void Configure(IApplicationBuilder app)
            {
            app.UseSession();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            app.UseMvc(config =>
            {
                config.MapRoute(name: "Default",
                                template: "{controller}/{action}/{id?}",
                                defaults: new { controller = "App", Action = "Index" });
            });
        }
    }
}
