using Microsoft.AspNetCore.Mvc;

namespace Contacts.Api.Controllers;


public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}