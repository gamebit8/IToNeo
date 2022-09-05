using FunctionalTests;
using IToNeo.FunctionalTests.WepApi;
using IToNeo.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI;
using Xunit;

namespace IToNeo.FunctionalTests.WebApi.Equipments
{
    [Collection("Collection")]
    public class DeleteEndpoint : IClassFixture<ComponentFixture>
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly IToNeoContext _context;
        private readonly string _adminAuthJwtToken;
        public DeleteEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _context = componentFixture.IToNeoDbContext;
            _adminAuthJwtToken = componentFixture.AdminAuthJwtToken;
            _baseUrl = componentFixture.Urls.EquipmentsUrl;
        }

        [Fact]
        public async Task ReturnNoContentAfterDeleteEquipment()
        {
            var testEquipmentId = _context.Equipments.FirstOrDefault().Id;
            var url = _baseUrl + testEquipmentId;        
            var authenticationHeader = new AuthenticationHeaderValue("bearer", _adminAuthJwtToken);

            var requestDelete = new HttpRequestMessage(HttpMethod.Delete, url);
            requestDelete.Headers.Authorization = authenticationHeader;
            var requestGet = new HttpRequestMessage(HttpMethod.Get, url);
            requestGet.Headers.Authorization = authenticationHeader;

            var responseDelete = await _client.SendAsync(requestDelete);
            var deleteStatusCode = responseDelete.StatusCode;
            var getByIdResponse = await _client.SendAsync(requestGet);
            var getByIdStatusCode = getByIdResponse.StatusCode;

            Assert.Equal(HttpStatusCode.NoContent, deleteStatusCode);
            Assert.Equal(HttpStatusCode.NotFound, getByIdStatusCode);
        }
    }
}