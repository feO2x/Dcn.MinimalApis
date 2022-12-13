using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using LinqToDB;
using LinqToDB.Data;

namespace Dcn.MinimalApis.DataAccess;

public static class CommonQueries
{
    public static Task<Contact?> GetContactWithAddressAsync(this DataConnection dataConnection, int id) =>
        dataConnection.GetTable<Contact>()
                      .LoadWith(c => c.Address)
                      .FirstOrDefaultAsync(c => c.Id == id);
}