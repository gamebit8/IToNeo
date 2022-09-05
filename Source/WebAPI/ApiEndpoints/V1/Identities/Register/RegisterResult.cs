namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.Register
{
    public class RegisterResult
    {
        public string EmailConfirmationUrl { get; set; }

        public RegisterResult() { }
        public RegisterResult(string emailConfirmationUrl)
        {
            EmailConfirmationUrl = emailConfirmationUrl;
        }
    }
}
