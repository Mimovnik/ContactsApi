using Contacts.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;