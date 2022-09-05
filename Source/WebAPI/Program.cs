using Autofac.Extensions.DependencyInjection;
using IToNeo.Infrastructure.Data;
using IToNeo.Infrastructure.Identity;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //Generate data in database 
                //var services = scope.ServiceProvider;
                //var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                //try
                //{
                //    var itoNeoContext = services.GetRequiredService<IToNeoContext>();
                //    itoNeoContext.Database.EnsureDeleted();
                //    itoNeoContext.Database.EnsureCreated();
                //    await IToNeoContextSeed.SeedAsync(itoNeoContext, loggerFactory, true);

                //    var itoNeoIdentityContext = services.GetRequiredService<IToNeoIdentityDbContext>();
                //    itoNeoIdentityContext.Database.EnsureDeleted();
                //    itoNeoIdentityContext.Database.EnsureCreated();

                //    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                //    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                //    await IToNeoIdentityDbContextSeed.SeedAsync(userManager, roleManager);
                //}
                //catch (Exception ex)
                //{
                //    var logger = loggerFactory.CreateLogger<Program>();
                //    logger.LogInformation(ex, "An error occurred seeding the DB.");
                //}

                host.Run();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
