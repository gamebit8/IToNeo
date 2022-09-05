namespace IToNeo.WebAPI.ApiEndpoints.V1.Identities.ResetPassword
{
    public class ResetPasswordResult
    {
        public string ResetPasswordUrl { get; set; }

        public ResetPasswordResult() { }

        public ResetPasswordResult(string resetPasswordUrl)
        {
            ResetPasswordUrl = resetPasswordUrl;
        }
    }
}
