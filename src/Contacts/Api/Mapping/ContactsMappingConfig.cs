using Contacts.Application.Contacts.Commands.Update;
using Contacts.Contracts.Contacts;
using Mapster;

namespace Contacts.Api.Mapping;

public class ContactsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid, UpdateContactRequest), UpdateContactCommand>()
            .Map(dest => dest.Id, src => src.Item1)
            .Map(dest => dest, src => src.Item2);
    }
}