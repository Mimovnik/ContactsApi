namespace Contacts.Contracts.Contacts;

public record CreateContactRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Category,
    string Subcategory,
    string PhoneNumber,
    string BirthDate
);