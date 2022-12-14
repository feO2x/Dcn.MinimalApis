using Microsoft.Extensions.DependencyInjection;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.NewContact;

public static class NewContactModule
{
    public static IServiceCollection AddNewContact(this IServiceCollection services) =>
        services.AddSessionFactoryFor<INewContactSession, LinqToDbNewContactSession>()
                .AddSingleton<NewContactDtoValidator>();
}