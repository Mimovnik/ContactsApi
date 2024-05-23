
using Contacts.Domain.Entities;

namespace Contacts.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);
    Task Add(User user);
}