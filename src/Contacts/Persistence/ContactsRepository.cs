using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using ErrorOr;

namespace Contacts.Persistence;

public class ContactsRepository : IContactsRepository
{
    private static readonly List<Contact> _contacts = new();

    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    public ErrorOr<IEnumerable<Contact>> GetAll()
    {
        return _contacts;
    }

    public Contact? GetById(Guid id)
    {
        return _contacts.SingleOrDefault(c => c.Id == id);
    }
}