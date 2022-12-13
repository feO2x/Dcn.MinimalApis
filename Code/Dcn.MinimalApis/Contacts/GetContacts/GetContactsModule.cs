using Microsoft.Extensions.DependencyInjection;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.GetContacts;

public static class GetContactsModule
{
    public static IServiceCollection AddGetContacts(this IServiceCollection services) =>
        services.AddSessionFactoryFor<IGetContactsSession, LinqToDbGetContactsSession>();
}