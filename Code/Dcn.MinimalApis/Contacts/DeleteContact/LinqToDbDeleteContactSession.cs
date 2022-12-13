using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess;
using Dcn.MinimalApis.DataAccess.Model;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.DeleteContact;

public sealed class LinqToDbDeleteContactSession : AsyncSession, IDeleteContactSession
{
    public LinqToDbDeleteContactSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<Contact?> GetContactAsync(int id) =>
        DataConnection.GetContactWithAddressAsync(id);

    public Task DeleteAddressAsync(Address address) => DataConnection.DeleteAsync(address);

    public Task DeleteContactAsync(Contact contact) => DataConnection.DeleteAsync(contact);
}