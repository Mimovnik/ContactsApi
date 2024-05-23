using System.Security.Cryptography;
using System.Text;
using Contacts.Application.Authentication.Common;
using Contacts.Application.Interfaces.Authentication;
using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using Contacts.Domain.Errors;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // 1. Validate the user exists
        if (await _userRepository.GetByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        using var hmac = new HMACSHA256(user.PasswordSalt);
        var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.Password));
        if (hash.Equals(user.PasswordHash))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}