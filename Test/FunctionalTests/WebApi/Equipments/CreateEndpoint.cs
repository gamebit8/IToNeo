using FunctionalTests;
using IToNeo.Infrastructure.Data;
using IToNeo.WebAPI.ApiEndpoints.Shared;
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
    public class CreateEndpoint : IClassFixture<ComponentFixture>
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
        private string _testTypeId;
        private string _testOrganizationId;
        private string _testStatusId;
        private string _testPlaceId;

        public CreateEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _context = componentFixture.IToNeoDbContext;
            _adminAuthJwtToken = componentFixture.AdminAuthJwtToken;
            _baseUrl = componentFixture.Urls.EquipmentsUrl;
            GetTestDataFromContextAndInitTestFileds();
        }

        private void GetTestDataFromContextAndInitTestFileds()
        {
            var equipment = _context.Equipments
                .Select(e => new { e.TypeId, e.OrganizationId, e.StatusId, e.PlaceId })
                .FirstOrDefault();

            _testTypeId = equipment.TypeId;
            _testOrganizationId = equipment.OrganizationId;
            _testStatusId = equipment.StatusId;
            _testPlaceId = equipment.PlaceId;
        }

        [Fact]
        public async Task ReturnNotNullCreateEquipmentAndCompareWithEquipmentFromContext()
        {
            var requestContent = new CreateEquipmentRequest()
            {
                Name = _testName,
                SerialNumber = _testSerialNumber,
                Note = _testNote,
                DateOfInstallation = _testDateOfInstallation,
                TypeId = _testTypeId,
                OrganizationId = _testOrganizationId,
                StatusId = _testStatusId,
                PlaceId = _testPlaceId
            };
            var jsonContent = new StringContent(JsonSerializer.Serialize(requestContent), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", _adminAuthJwtToken);
            request.Content = jsonContent;

            var response = await _client.SendAsync(request);
            var stringResponse = await response.Content.ReadAsStringAsync();
            var model = JsonSerializer.Deserialize<HateoasResponse>(stringResponse, _jsonOptions);
            var createdEquipmentId = new Uri(model.Href).Segments.LastOrDefault();
            var createdEquipmentFromContext = await _context.Equipments.FindAsync(createdEquipmentId);

            Assert.NotNull(model.Href);
            Assert.NotNull(model.Rel);
            Assert.NotNull(createdEquipmentFromContext);
            Assert.NotNull(createdEquipmentFromContext.InventoryNumber);
            Assert.NotNull(createdEquipmentFromContext.DateOfCreation);
            Assert.Equal(requestContent.Name, createdEquipmentFromContext.Name);
            Assert.Equal(requestContent.SerialNumber, createdEquipmentFromContext.SerialNumber);
            Assert.Equal(requestContent.Note, createdEquipmentFromContext.Note);
            Assert.Equal(requestContent.DateOfInstallation, createdEquipmentFromContext.DateOfInstallation);
            Assert.Equal(requestContent.TypeId, createdEquipmentFromContext.TypeId);
            Assert.Equal(requestContent.OrganizationId, createdEquipmentFromContext.OrganizationId);
            Assert.Equal(requestContent.StatusId, createdEquipmentFromContext.StatusId);
            Assert.Equal(requestContent.PlaceId, createdEquipmentFromContext.PlaceId);
        }
    }
}
