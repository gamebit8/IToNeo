using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ChangePasswordAfterReset
{
    public class ChangePasswordAfterResetRequest
    {
        [FromQuery] 
        public string Email { get; set; } 
        [FromQuery] 
        public string Token { get; set; }
        [FromBody] 
        public string NewPassword { get; set; } 
    }
}
