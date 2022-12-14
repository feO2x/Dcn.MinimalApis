using Microsoft.Extensions.DependencyInjection;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.GetContactDetails;

public static class GetContactDetailsModule
{
    public static IServiceCollection AddGetContactDetails(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IGetContactDetailsSession, LinqToDbGetContactDetailsSession>();
}