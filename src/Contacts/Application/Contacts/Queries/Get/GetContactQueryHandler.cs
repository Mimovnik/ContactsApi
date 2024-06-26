
using Contacts.Domain.Entities;
using Contacts.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;
using Contacts.Domain.Errors;

namespace Contacts.Application.Contacts.Queries.Get;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ErrorOr<Contact>>
{
    private readonly IContactsRepository _contactsRepository;

    public GetContactQueryHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ErrorOr<Contact>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _contactsRepository.GetById(request.Id);
        if (contact is null)
        {
            return Errors.Contact.NotFound;
        }
        return contact;
    }
}