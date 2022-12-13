using Dcn.MinimalApis.DataAccess.Model;
using Light.GuardClauses;

namespace Dcn.MinimalApis.Contacts;

public readonly record struct ContactDetailDto(int Id,
                                               string FirstName,
                                               string LastName,
                                               string Email,
                                               string Street,
                                               string ZipCode,
                                               string Location)
{
    public static ContactDetailDto FromContact(Contact contact)
    {
        var address = contact.Address.MustNotBeNull();
        return new(contact.Id,
                   contact.FirstName,
                   contact.LastName,
                   contact.Email,
                   address.Street,
                   address.ZipCode,
                   address.Location);
    }
}