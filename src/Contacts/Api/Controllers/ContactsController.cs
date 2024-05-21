using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Contacts.Application.Contacts.Queries;
using Contacts.Contracts;
using Contacts.Application.Contacts.Commands;

namespace Contacts.Api.Controllers;

[Route("[controller]")]
public class ContactsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public ContactsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactRequest request)
    {
        var command = _mapper.Map<CreateContactCommand>(request);

        var result = await _mediator.Send(command);

        return result.Match(
            contact => Ok(_mapper.Map<ContactResponse>(contact)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var query = new GetAllContactsQuery();

        var result = await _mediator.Send(query);

        return result.Match(
            contacts => Ok(_mapper.Map<IEnumerable<ContactResponse>>(contacts)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetContact(Guid id)
    {
        var query = new GetContactQuery(id);

        var result = await _mediator.Send(query);

        return result.Match(
            contact => Ok(_mapper.Map<ContactResponse>(contact)),
            errors => Problem(errors)
        );
    }
}