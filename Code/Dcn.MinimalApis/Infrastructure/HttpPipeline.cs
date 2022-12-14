using Dcn.MinimalApis.Contacts.GetContactDetails;
using Dcn.MinimalApis.Contacts.GetContacts;
using Dcn.MinimalApis.Heartbeat;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Dcn.MinimalApis.Infrastructure;

public static class HttpPipeline
{
    public static WebApplication ConfigureHttpPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsAndHstsIfNecessary();
        app.UseSerilogRequestLogging();
        app.UseRouting();
        app.UseSwaggerAndSwaggerUi();
        return app.MapEndpoints();
    }

    private static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapHeartbeatEndpoint()
           .MapGetContacts()
           .MapGetContactDetails()
           .AutomaticallyMapEndpoints()
           .MapControllers();
        return app;
    }

    private static void UseHttpsAndHstsIfNecessary(this WebApplication app)
    {
        var httpMode = app.Configuration.GetValue("httpMode", HttpMode.UseHsts);
        switch (httpMode)
        {
            case HttpMode.UseHttpsRedirection:
                app.UseHttpsRedirection();
                break;
            case HttpMode.UseHsts:
                app.UseHsts()
                   .UseHttpsRedirection();
                break;
        }
    }
}

public enum HttpMode
{
    AllowHttp,
    UseHttpsRedirection,
    UseHsts
}