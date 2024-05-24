using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Persistence;

public class ContactsRepository : IContactsRepository
{
    private readonly DatabaseContext _context;

    public ContactsRepository(DatabaseContext context)
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

    public async Task Update(Guid id, Contact newContact)
    {
        var old = await _context.Contacts.FindAsync(id);
        _context.Contacts.Update(old).CurrentValues.SetValues(newContact);

        await _context.SaveChangesAsync();
    }

    public async Task Remove(Contact contact)
    {
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
    }
}