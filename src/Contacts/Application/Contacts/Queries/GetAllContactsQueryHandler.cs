
using Contacts.Domain.Entities;
using Contacts.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Queries;

public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, ErrorOr<IEnumerable<Contact>>>
{
    private readonly IContactsRepository _contactsRepository;

    public GetAllContactsQueryHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ErrorOr<IEnumerable<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var contacts = _contactsRepository.GetAll();
        return contacts;
    }
}