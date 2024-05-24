
using Contacts.Domain.Entities;
using Contacts.Domain.Errors;
using Contacts.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Commands.Update;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ErrorOr<Contact>>
{
    private readonly IContactsRepository _contactsRepository;

    public UpdateContactCommandHandler(IContactsRepository contactsRepository)
    {
        _contactsRepository = contactsRepository;
    }

    public async Task<ErrorOr<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactsRepository.GetById(request.Id);

        if (contact == null)
        {
            return Errors.Contact.NotFound;
        }

        var updatedContact = new Contact
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Category = request.Category,
            Subcategory = request.Subcategory,
            PhoneNumber = request.PhoneNumber,
            BirthDate = request.BirthDate
        };

        if (contact.Email == updatedContact.Email)
        {
            await _contactsRepository.Update(contact.Id, updatedContact);
            return updatedContact;
        }

        // Validate that updated contact has unique email
        var existingContact = await _contactsRepository.GetByEmail(updatedContact.Email);
        if (existingContact != null)
        {
            return Errors.Contact.EmailAlreadyExists;
        }

        await _contactsRepository.Update(contact.Id, updatedContact);
        return updatedContact;
    }
}