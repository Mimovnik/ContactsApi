
using Contacts.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Contacts.Domain.Errors;

namespace Contacts.Application.Contacts.Commands.Remove;

public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, ErrorOr<OkResult>>
{
    private readonly IContactsRepository _contactsRepository;

    public RemoveContactCommandHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ErrorOr<OkResult>> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactsRepository.GetById(request.Id);
        if (contact is null)
        {
            return Errors.Contact.NotFound;
        }

        await _contactsRepository.Remove(contact);
        return new OkResult();
    }
}