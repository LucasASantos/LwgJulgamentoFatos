using System.Globalization;
using LDSI.Lwg.Apresentacao.Areas.Identity.ErrorDescriber;
using LDSI.Lwg.Apresentacao.Data.Context;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LDSI.Lwg.Apresentacao.Areas.Identity.IdentityHostingStartup))]
namespace LDSI.Lwg.Apresentacao.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        { 

          builder.ConfigureServices((context, services) => {

            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            services.AddDefaultIdentity<ApplicationUser>()
                 .AddErrorDescriber<PortugueseIdentityErrorDescriber>()
                 .AddEntityFrameworkStores<ApplicationDbContext>();

              services.Configure<IdentityOptions>(options =>
              {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 1;
              });
            });
        }
    }
}