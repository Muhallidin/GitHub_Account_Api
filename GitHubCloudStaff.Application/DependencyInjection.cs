
using GitHubCloudStaff.Application.Common;
using GitHubCloudStaff.Application.Common.Interface;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
 

namespace GitHubCloudStaff.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
           
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMemoryCache();
            return services;
        }
    }
}
