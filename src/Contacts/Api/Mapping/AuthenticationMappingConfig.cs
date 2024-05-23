using Contacts.Application.Authentication.Common;
using Contacts.Application.Authentication.Queries.Auth;
using Contacts.Contracts.Authentication;
using Mapster;

namespace Contacts.Api.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}