
using Contacts.Domain.Entities;

namespace Contacts.Application.Interfaces.Persistence;

public interface IContactsRepository
{
    Task Add(Contact contact);
    Task<List<Contact>> GetAll();
    Task<Contact?> GetByEmail(string email);
    Task<Contact?> GetById(Guid id);
    Task Remove(Contact contact);
}