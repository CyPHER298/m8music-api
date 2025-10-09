using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace M8MusicAPI.Controllers;

[Route("api/HelloWorld")]
[ApiController]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World");
    }
    
}