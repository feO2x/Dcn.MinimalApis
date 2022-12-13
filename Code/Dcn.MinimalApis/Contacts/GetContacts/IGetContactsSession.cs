using System.Collections.Generic;
using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.GetContacts;

public interface IGetContactsSession : IAsyncReadOnlySession
{
    Task<List<Contact>> GetContactsAsync(int skip, int take, string? searchTerm);
}