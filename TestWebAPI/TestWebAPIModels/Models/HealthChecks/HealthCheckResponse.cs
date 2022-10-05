namespace TestWebAPI.Model.Models.HealthChecks
{
    public class HealthCheckResponse
    {
        public string Status { get; init; }
        public IEnumerable<IndividualHealthCheckResponse> HealthCheck { get; init; }
        public TimeSpan HealthCheckDuration { get; init; }
    }
}
