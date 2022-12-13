using Dcn.MinimalApis.Contacts.DeleteContact;
using Dcn.MinimalApis.Contacts.GetContactDetails;
using Dcn.MinimalApis.Contacts.GetContacts;
using Dcn.MinimalApis.Contacts.NewContact;
using Dcn.MinimalApis.Contacts.UpdateContact;
using Microsoft.Extensions.DependencyInjection;

namespace Dcn.MinimalApis.Contacts;

public static class ContactsModule
{
    public static IServiceCollection AddContactsModule(this IServiceCollection services) =>
        services.AddGetContacts()
                .AddGetContactDetails()
                .AddNewContact()
                .AddDeleteContact()
                .AddUpdateContact();
}