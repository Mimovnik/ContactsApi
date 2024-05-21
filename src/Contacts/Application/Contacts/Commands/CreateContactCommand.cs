
using Contacts.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Commands;

public record CreateContactCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Category,
    string Subcategory,
    string PhoneNumber,
    string BirthDate) : IRequest<ErrorOr<Contact>>;