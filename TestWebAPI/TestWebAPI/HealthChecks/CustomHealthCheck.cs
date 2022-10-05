using System.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TestWebAPI.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy(e.Message);
            }

            return HealthCheckResult.Healthy("Custom Health Check is healthy");
        }
    }
}
