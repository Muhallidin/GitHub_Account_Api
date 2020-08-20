using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GitHubCloudStaff.Api
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                //try
                //{
                //    var context = service.GetRequiredService<ApplicationDbContext>();
                //    context.Database.Migrate();
                //}
                //catch (Exception ex)
                //{
                //    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                //    logger.LogError(ex, "An error occure while migrating or seeding the database");
                //}
            }
            host.Run();
        }
         
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();

    }
}
