using System.Threading.Tasks;
using Dcn.MinimalApis.DataAccess.Model;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.GetContactDetails;

public interface IGetContactDetailsSession : IAsyncReadOnlySession
{
    Task<Contact?> GetContactAsync(int id);
}