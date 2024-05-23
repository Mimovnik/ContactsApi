using Contacts.Domain.Constrains;
using FluentValidation;

namespace Contacts.Application.Authentication.Commands.Register;

public class RegisterCommanndValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommanndValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(UserConstrains.UsernameMinLength)
            .MaximumLength(UserConstrains.UsernameMaxLength);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(UserConstrains.PasswordMinLength)
            .MaximumLength(UserConstrains.PasswordMaxLength);
    }
}