using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.NewContact;

public interface INewContactSession : IAsyncSession
{
    Task<int> InsertContactAsync(Contact contact);
    Task<int> InsertAddressAsync(Address address);
}