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
    public class GetByIdEndpoint : IClassFixture<ComponentFixture>
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly IToNeoContext _context;
        private readonly string _adminAuthJwtToken;

        public GetByIdEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _context = componentFixture.IToNeoDbContext;
            _adminAuthJwtToken = componentFixture.AdminAuthJwtToken;
            _baseUrl = componentFixture.Urls.EquipmentsUrl;
        }

        [Fact]
        public async Task ReturnNotNullEquipmentByIdAndCompareWithEquipmentFromContext()
        {
            var testEquipmentFromContext = _context.Equipments.FirstOrDefault();
            var testUrl = _baseUrl + testEquipmentFromContext.Id;
            var authenticationHeader = new AuthenticationHeaderValue("bearer", _adminAuthJwtToken);

            var requestGet = new HttpRequestMessage(HttpMethod.Get, testUrl);
            requestGet.Headers.Authorization = authenticationHeader;

            var response = await _client.SendAsync(requestGet);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<BaseWithHateoasResponse<GetByIdEquipmentResult>>(stringResponse, _jsonOptions);

            Assert.NotNull(model);
            Assert.NotNull(testEquipmentFromContext);
            Assert.Equal(model.Data.Name, testEquipmentFromContext.Name);
            Assert.Equal(model.Data.SerialNumber, testEquipmentFromContext.SerialNumber);
            Assert.Equal(model.Data.Note, testEquipmentFromContext.Note);
            Assert.Equal(model.Data.DateOfInstallation, testEquipmentFromContext.DateOfInstallation);
            Assert.Equal(model.Data.Type.Id, testEquipmentFromContext.TypeId);
            Assert.Equal(model.Data.Organization.Id, testEquipmentFromContext.OrganizationId);
            Assert.Equal(model.Data.Status.Id, testEquipmentFromContext.StatusId);
            Assert.Equal(model.Data.Place.Id, testEquipmentFromContext.PlaceId);
            Assert.Equal(model.Data.Employee.Id, testEquipmentFromContext.EmployeeId);
        }
    }
}
