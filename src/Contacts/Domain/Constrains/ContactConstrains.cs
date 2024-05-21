using System.Text.RegularExpressions;

namespace Contacts.Domain.Constrains;

public static class ContactConstrains
{
    public const int FirstNameMaxLength = 50;
    public const int LastNameMaxLength = 50;
    public const int PasswordMinLength = 8;
    public const int PasswordMaxLength = 50;
    public enum Category
    {
        Business,
        Private,
        Other,
    }
    public const int SubcategoryMaxLength = 50;
    public const int PhoneNumberLength = 9;
    public const string PhoneNumberPattern = @"^(\d{9})$";
    public const string DatePattern = @"^(\d{4}-\d{2}-\d{2})$";
}