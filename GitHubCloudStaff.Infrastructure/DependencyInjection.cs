using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubCloudStaff.Infrastructure
{
    public class DependencyInjection
    {
        // Database implementation would be declare here.
    }
    //public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    //{
    //    services.AddDbContext<ApplicationDbContext>(options =>
    //           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    //    services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

    //    services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    //        .AddEntityFrameworkStores<ApplicationDbContext>();

    //    services.AddIdentityServer()
    //        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

    //    services.AddAuthentication()
    //        .AddIdentityServerJwt();

    //    return services;
    //}
}
