using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess;
using Dcn.MinimalApis.DataAccess.Model;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.UpdateContact;

public sealed class LinqToDbUpdateContactSession : AsyncSession, IUpdateContactSession
{
    public LinqToDbUpdateContactSession(DataConnection dataConnection) : base(dataConnection) { }
    
    public Task<Contact?> GetContactAsync(int id) =>
        DataConnection.GetContactWithAddressAsync(id);

    public Task UpdateContactAsync(Contact contact) =>
        DataConnection.UpdateAsync(contact);

    public Task UpdateAddressAsync(Address address) =>
        DataConnection.UpdateAsync(address);
}