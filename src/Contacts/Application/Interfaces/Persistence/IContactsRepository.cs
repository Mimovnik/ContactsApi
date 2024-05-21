
using Contacts.Domain.Entities;
using ErrorOr;

namespace Contacts.Application.Interfaces.Persistence;

public interface IContactsRepository
{
    void Add(Contact contact);
    ErrorOr<IEnumerable<Contact>> GetAll();
    Contact? GetById(Guid id);
}