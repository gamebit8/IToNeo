using IToNeo.ApplicationCore.Interfaces;
using IToNeo.FunctionalTests.WepApi;
using IToNeo.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI;

namespace FunctionalTests
{
    public class ComponentFixture
    {
        private ITokenClaimsService _claimsService;
        public Urls Urls = new();
        public string AdminAuthJwtToken { get; private set; }
        public HttpClient Client { get; private set; }
        public IToNeoContext IToNeoDbContext { get; private set; } 

        public ComponentFixture()
        {
            var app = new TestApiApplication<Startup>();

            Client = app.Client;
            IToNeoDbContext = app.Services.GetService<IToNeoContext>();
            _claimsService = app.Services.GetService<ITokenClaimsService>();
            Task.Run(() => SetAdminAuthJwtToken()).Wait();
        }

        private async Task SetAdminAuthJwtToken()
        {
            AdminAuthJwtToken = await _claimsService.GetTokenAsync("admin@microsoft.com");
        }

    }
}
