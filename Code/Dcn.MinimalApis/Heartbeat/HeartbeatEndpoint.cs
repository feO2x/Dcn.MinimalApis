using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Dcn.MinimalApis.Heartbeat;

public static class HeartbeatEndpoint
{
    public static WebApplication MapHeartbeatEndpoint(this WebApplication app)
    {
        app.MapGet("/", GetHeartbeat)
           .Produces<string>();
        return app;
    }

    /// <summary>
    /// This endpoint can be used to check if the service is reachable.
    /// It will always return "Service is alive" when being called successfully.
    /// </summary>
    public static string GetHeartbeat() => "Service is alive";
}