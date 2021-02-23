using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameLibrary.Areas.Identity.Data;
using VideoGameLibrary.Data;

[assembly: HostingStartup(typeof(VideoGameLibrary.Areas.Identity.IdentityHostingStartup))]
namespace VideoGameLibrary.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<VideoGameLibraryUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityContext>();

                services.Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGIJKLMNOPQRSTUVWXYZ0123456789_";
                });
            });
        }
    }
}