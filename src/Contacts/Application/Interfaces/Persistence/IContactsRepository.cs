
using Contacts.Domain.Entities;

namespace Contacts.Application.Interfaces.Persistence;

public interface IContactsRepository
{
    Task Add(Contact contact);
    Task<List<Contact>> GetAll();
    Task<Contact?> GetByEmail(string email);
    Task<Contact?> GetById(Guid id);
    Task Update(Guid id, Contact newContact);
    Task Remove(Contact contact);
}