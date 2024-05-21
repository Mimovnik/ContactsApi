
using ErrorOr;

namespace Contacts.Domain.Errors;

public static partial class Errors
{
    public static class Contact
    {
        public static Error NotFound => Error.NotFound(
            code: "Contact.NotFound",
            description: "The requested contact was not found."
        );
    }
}