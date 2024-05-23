
using Contacts.Domain.Entities;

namespace Contacts.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);