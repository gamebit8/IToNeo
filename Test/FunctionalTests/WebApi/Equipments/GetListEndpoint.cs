using FunctionalTests;
using IToNeo.Infrastructure.Data;
using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.FunctionalTests.WebApi.Equipments
{
    [Collection("Collection")]
    public class GetListEndpoint : IClassFixture<ComponentFixture>
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly IToNeoContext _context;
        private readonly string _adminAuthJwtToken;

        public GetListEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _context = componentFixture.IToNeoDbContext;
            _adminAuthJwtToken = componentFixture.AdminAuthJwtToken;
            _baseUrl = componentFixture.Urls.EquipmentsUrl;
        }

        [Fact]
        public async Task ReturnNotNullEquipments()
        {
            var equipmentsFromContext = _context.Equipments.ToList();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", _adminAuthJwtToken);

            var response = await _client.SendAsync(request);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<BaseListWithHateoasResponse<GetEquipmentsResult>>(stringResponse, _jsonOptions);

            Assert.NotNull(model.Data);
            Assert.NotNull(model.Link);
            Assert.NotNull(equipmentsFromContext);
            Assert.Equal(equipmentsFromContext.Count, model.Data.Count());
        }
    }
}