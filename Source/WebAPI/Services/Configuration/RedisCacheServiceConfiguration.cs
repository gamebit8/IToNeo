namespace IToNeo.WebAPI.Services.Configuration
{
    public class RedisCacheServiceConfiguration
    {
        public const string RedisCache = "RedisCache";

        public bool IsEnable { get; set; }
        public string ServerAddress { get; set; }
        public string InstanceName { get; set; }
        public int ExpirationRelativeInMinutes { get; set; }
    }
}
