using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Data.Repositories;
using LDSI.Lwg.Apresentacao.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LDSI.Lwg.Apresentacao.IoC;
using LDSI.Lwg.Apresentacao.Hubs;

namespace LDSI.Lwg.Apresentacao
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
              .Configure<CookiePolicyOptions>(options =>
              {
                  options.CheckConsentNeeded = context => true;
                  options.MinimumSameSitePolicy = SameSiteMode.None;
              });

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseMySQL(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc()
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Professor", policy => policy.RequireClaim("Professor"));
            });

            IoC.IoC.Configure(services);

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSignalR(routes =>
            {
                routes.MapHub<JFHub>("/jfexec");
            });
        }
    }
}
