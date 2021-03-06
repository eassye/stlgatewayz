﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace GatewayZ
{
    public class Startup
        {
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddMvc();
            services.AddDirectoryBrowser();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=App}/{action=Index}/{id?}")
                .MapRoute(name: "About", template: "{controller=About}/{action=Index}/{id?}")
                .MapRoute(name: "Events", template: "{controller=Events}/{action=Index}/{id?}")
                .MapRoute(name: "Register", template: "{controller=Register}/{action=Index}/{id?}")
                .MapRoute(name: "History", template: "{controller=History}/{action=Index}/{id?}")
                .MapRoute(name: "Admin", template: "{controller=Admin}/{action=Index}/{id?}")
                .MapRoute(name: "Gallery2002", template: "{controller=Gallery2002}/{action=Index}/{id?}")
                .MapRoute(name: "Gallery2003CarShow", template: "{controller=Gallery2003CarShow}/{action=Index}/{id?}")
                .MapRoute(name: "EditUser", template: "{controller=EditUser}/{action=Index}/{id?}")
                .MapRoute(name: "RecoverPassword", template: "{controller=RecoverPassword}/{action=Index}/{id?}")
                .MapRoute(name: "Members", template: "{controller=Members}/{action=Index}/{id?}")
                .MapRoute(name: "UnauthorizedUser", template: "{controller=UnauthorizedUser}/{action=Index}/{id?}")
                .MapRoute(name: "SignUp", template: "{controller=SignUp}/{action=Index}/{id?}");
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images")),
                RequestPath = new PathString("/Gallery")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
                RequestPath = new PathString("/Gallery")
            });
        }
    }
}
