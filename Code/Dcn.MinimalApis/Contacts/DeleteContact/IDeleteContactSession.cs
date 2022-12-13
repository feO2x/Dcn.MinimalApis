using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.DeleteContact;

public interface IDeleteContactSession : IAsyncSession
{
    Task<Contact?> GetContactAsync(int id);
    Task DeleteAddressAsync(Address address);
    Task DeleteContactAsync(Contact contact);
}