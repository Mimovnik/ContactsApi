using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Persistence;

public class ContactsRepository : IContactsRepository
{
    private readonly ContactsContext _context;

    public ContactsRepository(ContactsContext context)
    {
        _context = context;
    }

    public async Task Add(Contact contact)
    {
        _context.Contacts.Add(contact);

        await _context.SaveChangesAsync();
    }

    public async Task<List<Contact>> GetAll()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async Task<Contact?> GetByEmail(string email)
    {
        return await _context.Contacts.SingleOrDefaultAsync(c => c.Email == email);
    }

    public Task<Contact?> GetById(Guid id)
    {
        return _context.Contacts.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task Remove(Contact contact)
    {
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }
}