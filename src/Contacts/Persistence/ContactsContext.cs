using Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Persistence;

public class ContactsContext : DbContext
{
    public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
}