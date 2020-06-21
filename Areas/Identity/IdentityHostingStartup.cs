using System;
using COREDemo.Areas.Identity.Data;
using COREDemo.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(COREDemo.Areas.Identity.IdentityHostingStartup))]
namespace COREDemo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<COREDemoContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("COREDemoContextConnection")));

                services.AddDefaultIdentity<COREDemoUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<COREDemoContext>();
            });
        }
    }
}