using System.Collections.Generic;
using System.Threading.Tasks;
using Light.Validation;
using Light.Validation.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.GetContacts;

public static class GetContactsEndpoint
{
    public static WebApplication MapGetContacts(this WebApplication app)
    {
        app.MapGet("/api/contacts", GetContacts)
           .Produces<ContactListDto[]>()
           .Produces<Dictionary<string, string>>(StatusCodes.Status400BadRequest)
           .Produces(StatusCodes.Status500InternalServerError);
        return app;
    }

    /// <summary>
    /// Gets a list of contacts (paged).
    /// </summary>
    /// <param name="validationContext">The validation context that is used to track errors.</param>
    /// <param name="sessionFactory">The factory that creates the session to the database.</param>
    /// <param name="skip">
    /// The number of contacts that will be skipped for paging (optional). The default value is 0.
    /// </param>
    /// <param name="take">
    /// The number of contacts that will be included in the result (optional). The default value is 30.
    /// This value must be between 1 and 100.
    /// </param>
    /// <param name="searchTerm">The search term that is used to filter the contacts (optional). The default value is null.</param>
    /// <response code="400">Occurs when skip is less than 0, or when take is not between 1 and 100.</response>
    public static async Task<IResult> GetContacts(ValidationContext validationContext,
                                                  ISessionFactory<IGetContactsSession> sessionFactory,
                                                  int skip = 0,
                                                  int take = 30,
                                                  string? searchTerm = null)
    {
        if (validationContext.CheckForPagingErrors(skip, take, out var errors))
            return Results.BadRequest(errors);

        searchTerm = searchTerm.NormalizeString();
        await using var session = await sessionFactory.OpenSessionAsync();
        var contacts = await session.GetContactsAsync(skip, take, searchTerm);
        return Results.Ok(ContactListDto.FromContacts(contacts));
    }
}