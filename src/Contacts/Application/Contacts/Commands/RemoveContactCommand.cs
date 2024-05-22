using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Application.Contacts.Commands;

public record RemoveContactCommand(Guid Id) : IRequest<ErrorOr<OkResult>>;