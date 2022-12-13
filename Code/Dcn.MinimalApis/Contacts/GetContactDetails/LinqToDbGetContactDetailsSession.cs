using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess;
using Dcn.MinimalApis.DataAccess.Model;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.GetContactDetails;

public sealed class LinqToDbGetContactDetailsSession : AsyncReadOnlySession, IGetContactDetailsSession
{
    public LinqToDbGetContactDetailsSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<Contact?> GetContactAsync(int id) => DataConnection.GetContactWithAddressAsync(id);
}