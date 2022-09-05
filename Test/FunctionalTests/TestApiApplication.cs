using IToNeo.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace IToNeo.FunctionalTests.WepApi
{
    public class TestApiApplication<TStartup> where TStartup : class
    {
        public HttpClient Client { get; private set; }
        public IServiceProvider Services { get; private set; }
        public TestApiApplication()
        {
            var server = new WebApplicationFactory<TStartup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var sp = services.BuildServiceProvider();

                    using (var scope = sp.CreateScope())
                    {
                        var sevices = scope.ServiceProvider;
                        var loggerFactory = sevices.GetRequiredService<ILoggerFactory>();

                        try
                        {
                            var itoNeoContext = sevices.GetService<IToNeoContext>();
                            itoNeoContext.Database.EnsureDeleted();
                            itoNeoContext.Database.EnsureCreated();
                            IToNeoContextSeed.Seed(itoNeoContext, loggerFactory);
                        }
                        catch (Exception ex)
                        {
                            var logger = loggerFactory.CreateLogger<TestApiApplication<TStartup>>();
                            logger.LogInformation(ex, "An error occurred seeding the DB.");
                        }
                    }
                });
            });

            Services = server.Services;
            Client = server.CreateClient();
        }
    }
}


