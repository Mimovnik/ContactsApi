using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers;

[Route("[controller]")]
public class ContactsController : ControllerBase
{
    [HttpGet]
    public IActionResult ListContacts()
    {
        return Ok(Array.Empty<string>());
    }
}