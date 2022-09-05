using System.Collections.Generic;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.Authenticate
{
    public class AuthenticateResult
    {
        public bool Result { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public IEnumerable<string> Roles { get; set; } = default;
        public bool IsLockedOut { get; set; } = false;
        public bool IsNotAllowed { get; set; } = false;
        public bool RequiresTwoFactor { get; set; } = false;
    }
}
