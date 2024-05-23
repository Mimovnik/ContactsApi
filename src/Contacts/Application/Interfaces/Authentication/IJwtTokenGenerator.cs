using Contacts.Domain.Entities;

namespace Contacts.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}