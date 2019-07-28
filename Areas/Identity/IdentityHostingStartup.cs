using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OutOfOffice.Areas.Identity.Data;

[assembly: HostingStartup(typeof(OutOfOffice.Areas.Identity.IdentityHostingStartup))]
namespace OutOfOffice.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OutOfOfficeIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OutOfOfficeIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<OutOfOfficeIdentityDbContext>();
            });
        }
    }
}