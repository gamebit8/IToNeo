namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ChangePassword
{
    public class ChangePasswordRequest
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
