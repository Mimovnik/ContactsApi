using FluentValidation;
using static Contacts.Domain.Constrains.ContactConstrains;

namespace Contacts.Application.Contacts.Commands;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(FirstNameMaxLength);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(LastNameMaxLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(PasswordMinLength)
            .MaximumLength(PasswordMaxLength);

        string categories = string.Join(", ", Enum.GetNames(typeof(Category)));
        RuleFor(x => x.Category)
            .NotEmpty()
            .IsEnumName(typeof(Category))
            .WithMessage($"'Category' must be one of the following values: {categories}");

        RuleFor(x => x.Subcategory)
            .NotEmpty()
            .MaximumLength(SubcategoryMaxLength);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Length(PhoneNumberLength)
            .Matches(PhoneNumberPattern)
            .WithMessage("'Phone Number' must be in the format: 123456789");

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Matches(DatePattern)
            .WithMessage("'Birth Date' must be in the format: yyyy-MM-dd");
    }
}