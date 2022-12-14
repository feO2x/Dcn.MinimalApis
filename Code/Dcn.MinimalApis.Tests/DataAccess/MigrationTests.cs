using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess;
using Light.Xunit;
using LightInject.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Synnotech.Migrations.Linq2Db.Int64TimestampVersions;
using Synnotech.MsSqlServer;
using Xunit;
using Xunit.Abstractions;

namespace Dcn.MinimalApis.Tests.DataAccess;

public sealed class MigrationsTests
{
    public MigrationsTests(ITestOutputHelper output) =>
        Logger = output.CreateTestLogger();

    private ILogger Logger { get; }

    [SkippableFact]
    public async Task RunAllMigrations()
    {
        Skip.IfNot(TestSettings.Configuration.GetValue<bool>("migrations:areTestsEnabled"));
        var container = new ServiceCollection().AddSingleton(TestSettings.Configuration)
                                               .AddDataAccess("migrations")
                                               .CreateLightInjectServiceProvider();

        var connectionString = TestSettings.Configuration["migrations:connectionString"]!;
        await Database.DropAndCreateDatabaseAsync(connectionString);
        var migrationEngine = container.GetRequiredService<MigrationEngine>();
        await migrationEngine.MigrateAndLogAsync(Logger);
    }
}