namespace IToNeo.WebAPI.Services.Configuration
{
    public class EventBusServiceConfiguration
    {
        public const string EventBus = "EventBus";

        public string Connection { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SubscriptionClientName { get; set; }
        public int RetryCount { get; set; }
    }
}
