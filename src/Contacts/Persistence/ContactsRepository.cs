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

    public async Task<ErrorOr<IEnumerable<Contact>>> GetAll()
    {
        return await _context.Contacts.ToListAsync();
    }

    public Task<Contact?> GetById(Guid id)
    {
        return _context.Contacts.SingleOrDefaultAsync(c => c.Id == id);
    }

    public async Task Remove(Contact contact)
    {
        await Task.CompletedTask;
        _context.Contacts.Remove(contact);
    }
}