
using Contacts.Domain.Entities;
using ErrorOr;

namespace Contacts.Application.Interfaces.Persistence;

public interface IContactsRepository
{
    Task Add(Contact contact);
    Task<ErrorOr<IEnumerable<Contact>>> GetAll();
    Task<Contact?> GetById(Guid id);
    Task Remove(Contact contact);
}