using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Light.GuardClauses;
using LinqToDB;
using LinqToDB.Data;
using Synnotech.Linq2Db;

namespace Dcn.MinimalApis.Contacts.GetContacts;

public sealed class LinqToDbGetContactsSession : AsyncReadOnlySession, IGetContactsSession
{
    public LinqToDbGetContactsSession(DataConnection dataConnection) : base(dataConnection) { }

    public Task<List<Contact>> GetContactsAsync(int skip, int take, string? searchTerm)
    {
        IQueryable<Contact> query = DataConnection.GetTable<Contact>();

        if (!searchTerm.IsNullOrWhiteSpace())
            query = query.Where(c => c.FirstName.StartsWith(searchTerm) ||
                                     c.LastName.StartsWith(searchTerm));

        return query.OrderBy(c => c.LastName)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
    }
}