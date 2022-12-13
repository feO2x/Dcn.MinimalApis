using Microsoft.AspNetCore.Mvc;

namespace Dcn.MinimalApis.Heartbeat;

[ApiController]
[Route("/mvc")]
public sealed class HeartbeatController : ControllerBase
{
    [HttpGet]
    public string GetHeartbeat() => "Service is alive";
}