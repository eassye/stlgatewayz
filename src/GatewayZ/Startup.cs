﻿using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GatewayZ
{
    public class Startup
        {
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();
            services.AddCaching();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieName = ".Gatewayz";
            });
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app)
            {
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(name: "Default",
                                template: "{controller}/{action}/{id?}",
                                defaults: new { controller = "App", Action = "Index" });
            });
        }
        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
