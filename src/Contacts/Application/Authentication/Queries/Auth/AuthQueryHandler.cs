
using Contacts.Application.Authentication.Common;
using Contacts.Application.Interfaces.Authentication;
using Contacts.Application.Interfaces.Persistence;
using Contacts.Domain.Entities;
using Contacts.Domain.Errors;
using ErrorOr;
using MediatR;

namespace Contacts.Application.Authentication.Queries.Auth;

public class LoginQueryHandler : IRequestHandler<AuthQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(AuthQuery query, CancellationToken cancellationToken)
    {
        await _userRepository.GetByEmail(query.Email);
        if (await _userRepository.GetByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Refresh JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
