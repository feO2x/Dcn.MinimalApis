using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.UpdateContact;

public interface IUpdateContactSession : IAsyncSession
{
    Task<Contact?> GetContactAsync(int id);
    Task UpdateContactAsync(Contact contact);
    Task UpdateAddressAsync(Address address);
}