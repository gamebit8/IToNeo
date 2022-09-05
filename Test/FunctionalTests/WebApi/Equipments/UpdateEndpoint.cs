using FunctionalTests;
using IToNeo.Infrastructure.Data;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.FunctionalTests.WebApi.Equipments
{
    [Collection("Collection")]
    public class UpdateEndpoint : IClassFixture<ComponentFixture>
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly IToNeoContext _context;
        private readonly string _adminAuthJwtToken;
        private string _testName = "TestName";
        private string _testSerialNumber = "TestSerialNumber";
        private string _testNote = "TestNote";
        private DateTime _testDateOfInstallation = DateTime.Now.Date;

        public UpdateEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _context = componentFixture.IToNeoDbContext;
            _adminAuthJwtToken = componentFixture.AdminAuthJwtToken;
            _baseUrl = componentFixture.Urls.EquipmentsUrl;
        }

        [Fact]
        public async Task ReturnNotNullUpdateEquipment()
        {
            var testEquipmentFromContext = _context.Equipments.FirstOrDefault();
            var testUrl = _baseUrl + testEquipmentFromContext.Id;
            var authenticationHeader = new AuthenticationHeaderValue("bearer", _adminAuthJwtToken);
            var requestBody = new UpdateEquipmentRequestBody()
            {
                Name = _testName,
                SerialNumber = _testSerialNumber,
                Note = _testNote,
                DateOfInstallation = _testDateOfInstallation,
                TypeId = testEquipmentFromContext.TypeId,
                OrganizationId = testEquipmentFromContext.OrganizationId,
                StatusId = testEquipmentFromContext.StatusId,
                PlaceId = testEquipmentFromContext.PlaceId,
                EmployeeId = testEquipmentFromContext.EmployeeId
            };

            var request = new HttpRequestMessage(HttpMethod.Put, testUrl);
            request.Headers.Authorization = authenticationHeader;
            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _client.SendAsync(request);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<UpdateEquipmentResult>(stringResponse, _jsonOptions);

            Assert.NotNull(model);
            Assert.Equal(model.Name, requestBody.Name);
            Assert.Equal(model.SerialNumber, requestBody.SerialNumber);
            Assert.Equal(model.Note, requestBody.Note);
            Assert.Equal(model.DateOfInstallation, requestBody.DateOfInstallation);
            Assert.Equal(model.TypeId, requestBody.TypeId);
            Assert.Equal(model.OrganizationId, requestBody.OrganizationId);
            Assert.Equal(model.StatusId, requestBody.StatusId);
            Assert.Equal(model.PlaceId, requestBody.PlaceId);
            Assert.Equal(model.EmployeeId, requestBody.EmployeeId);
        }
    }
}