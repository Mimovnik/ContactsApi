
using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(c => c.Email == email);
    }

    public async Task Add(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }
}