namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ConfirmEmail
{
    public class ConfirmEmailRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
