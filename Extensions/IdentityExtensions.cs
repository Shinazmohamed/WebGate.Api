using Microsoft.AspNetCore.Identity;
using WebGate.EntityFramework.Entities;
using WebGate.EntityFramework;

namespace WebGate.Api.Extensions
{
    public static class IdentityExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(i =>
            {
                i.Password.RequireDigit = false;
                i.Password.RequireLowercase = false;
                i.Password.RequireUppercase = false;
                i.Password.RequireNonAlphanumeric = false;
                i.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<WebGateDbContext>()
            .AddDefaultTokenProviders();

        }
    }
}
