
using Contacts.Domain.Entities;
using Contacts.Domain.Errors;
using Contacts.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Commands.Create;

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ErrorOr<Contact>>
{
    private readonly IContactsRepository _contactsRepository;

    public CreateContactCommandHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ErrorOr<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Category = request.Category,
            Subcategory = request.Subcategory,
            PhoneNumber = request.PhoneNumber,
            BirthDate = request.BirthDate
        };

        // Validate thet contact has unique email
        var existingContact = await _contactsRepository.GetByEmail(contact.Email);
        if (existingContact != null)
        {
            return Errors.Contact.EmailAlreadyExists;
        }

        await _contactsRepository.Add(contact);

        return contact;
    }
}