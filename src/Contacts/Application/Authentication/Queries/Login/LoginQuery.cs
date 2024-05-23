using Contacts.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;