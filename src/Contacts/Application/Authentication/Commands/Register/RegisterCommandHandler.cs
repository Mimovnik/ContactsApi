using System.Security.Cryptography;
using System.Text;
using Contacts.Application.Authentication.Common;
using Contacts.Application.Interfaces.Authentication;
using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using Contacts.Domain.Errors;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        // 1. Validate the user doesn't exist
        if (await _userRepository.GetByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // 2.  Create user and add to database
        using var hmac = new HMACSHA256();
        var user = new User
        {
            Username = command.Username,
            Email = command.Email,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(command.Password)),
            PasswordSalt = hmac.Key
        };

        await _userRepository.Add(user);

        // 3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}