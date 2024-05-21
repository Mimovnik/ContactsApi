namespace Contacts.Domain.Entities;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Subcategory { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string BirthDate { get; set; } = null!;
}