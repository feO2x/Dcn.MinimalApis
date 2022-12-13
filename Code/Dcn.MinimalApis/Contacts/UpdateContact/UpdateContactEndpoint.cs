using System.Collections.Generic;
using System.Threading.Tasks;
using Dcn.MinimalApis.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Synnotech.DatabaseAbstractions;

namespace Dcn.MinimalApis.Contacts.UpdateContact;

public sealed class UpdateContactEndpoint : IMinimalApiEndpoint
{
    public UpdateContactEndpoint(UpdateContactDtoValidator validator,
                                 ISessionFactory<IUpdateContactSession> sessionFactory,
                                 ILogger logger)
    {
        Validator = validator;
        SessionFactory = sessionFactory;
        Logger = logger;
    }

    private UpdateContactDtoValidator Validator { get; }
    private ISessionFactory<IUpdateContactSession> SessionFactory { get; }
    private ILogger Logger { get; }

    public void MapEndpoint(WebApplication app)
    {
        app.MapPut("/api/contacts/update", UpdateContact)
           .Produces(StatusCodes.Status204NoContent)
           .Produces<Dictionary<string, string>>(StatusCodes.Status400BadRequest)
           .Produces(StatusCodes.Status500InternalServerError);
    }

    /// <summary>
    /// Use this endpoint to update an existing contact.
    /// </summary>
    /// <param name="dto">The DTO describing the ID of the contact and its new values.</param>
    /// <response code="400">Occurs when the DTO is null or when any of the properties is invalid.</response>
    public async Task<IResult> UpdateContact(UpdateContactDto? dto)
    {
        if (Validator.CheckForErrors(dto, out var errors))
            return Results.BadRequest(errors);

        await using var session = await SessionFactory.OpenSessionAsync();
        var contact = await session.GetContactAsync(dto.Id);
        if (contact is null)
            return Results.NotFound();

        contact.FirstName = dto.FirstName;
        contact.LastName = dto.LastName;
        contact.Email = dto.Email;
        await session.UpdateContactAsync(contact);

        var address = contact.Address!;
        address.Street = dto.Street;
        address.ZipCode = dto.ZipCode;
        address.Location = dto.Location;
        await session.UpdateAddressAsync(address); 

        await session.SaveChangesAsync();

        Logger.Information("The contact {@Contact} was updated successfully", contact);
        return Results.NoContent();
    }
}