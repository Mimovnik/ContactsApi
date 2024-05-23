using Contacts.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Queries.GetAll;

public record GetAllContactsQuery : IRequest<ErrorOr<IEnumerable<Contact>>>;
