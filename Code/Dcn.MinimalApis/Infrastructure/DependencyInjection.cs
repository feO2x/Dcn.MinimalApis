using Dcn.MinimalApis.Contacts;
using Dcn.MinimalApis.DataAccess;
using Light.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dcn.MinimalApis.Infrastructure;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureDependencyInjectionContainer(this WebApplicationBuilder builder)
    {
        builder.Host.UseLightInject();
        builder.Services.ConfigureServices();
        return builder;
    }

    private static void ConfigureServices(this IServiceCollection services) =>
        services.AddSwagger()
                .AddCoreServices()
                .AddDataAccess()
                .AddContactsModule()
                .AddAutomaticEndpoints()
                .AddControllers();

    private static IServiceCollection AddCoreServices(this IServiceCollection services) =>
        services.AddSingleton<IValidationContextFactory>(ValidationContextFactory.Instance)
                .AddTransient(container => container.GetRequiredService<IValidationContextFactory>().CreateValidationContext());
}