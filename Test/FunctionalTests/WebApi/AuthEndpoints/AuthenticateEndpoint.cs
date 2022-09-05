using FunctionalTests;
using IToNeo.ApplicationCore.Constants;
using IToNeo.WebAPI.ApiEndpoints.V1.Identities.Authenticate;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.FunctionalTests.AuthEndpoints
{
    [Collection("Collection")]
    public class AuthenticateEndpoint : IClassFixture<ComponentFixture>
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        public AuthenticateEndpoint(ComponentFixture componentFixture)
        {
            _client = componentFixture.Client;
            _baseUrl = componentFixture.Urls.AuthenticateUrl;
        }

        [Theory]
        [InlineData("admin@microsoft.com", AuthorizationConstants.DEFAULT_PASSWORD, HttpStatusCode.OK)]
        [InlineData("admin@microsoft.com", "badpassword", HttpStatusCode.BadRequest)]
        public async Task ReturnsExpectedResultGivenCredentials(string testUsername, string testPassword, HttpStatusCode statusCode)
        {
            var request = new AuthenticateRequest()
            {
                Username = testUsername,
                Password = testPassword
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_baseUrl, jsonContent);

            Assert.Equal(response.StatusCode, statusCode);   
        }
    }
}
