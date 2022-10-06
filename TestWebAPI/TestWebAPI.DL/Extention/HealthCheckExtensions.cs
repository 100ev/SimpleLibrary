using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using TestWebAPI.Model.Models.HealthChecks;

namespace TestWebAPI.DL.Extention
{
    public static class HealthCheckExtensions
    {
        public static IApplicationBuilder RegisterHealthChecks(this IApplicationBuilder app)
        {
            return app.UseHealthChecks("/healthz", new HealthCheckOptions() {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    var response = new HealthCheckResponse
                    {
                        Status = report.Status.ToString(),
                        HealthCheck = report.Entries.Select(x => new IndividualHealthCheckResponse()
                        {
                            Component = x.Key,
                            Status = x.Value.Status.ToString(),
                            description = x.Value.Description
                        }),
                        HealthCheckDuration = report.TotalDuration
                    };

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response, Formatting.Indented));
                }
            });
        }
    }
}
