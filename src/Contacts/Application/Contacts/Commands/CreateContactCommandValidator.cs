

using FluentValidation;

namespace Contacts.Application.Contacts.Commands;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);

        RuleFor(x => x.Category)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Subcategory)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.BirthDate)
            .NotEmpty();
    }
}