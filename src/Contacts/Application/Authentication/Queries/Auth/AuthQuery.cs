using Contacts.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Queries.Auth;


public record AuthQuery(string Email) : IRequest<ErrorOr<AuthenticationResult>>;