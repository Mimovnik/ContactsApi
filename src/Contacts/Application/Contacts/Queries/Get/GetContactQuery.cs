using Contacts.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Contacts.Queries.Get;

public record GetContactQuery(Guid Id) : IRequest<ErrorOr<Contact>>;
