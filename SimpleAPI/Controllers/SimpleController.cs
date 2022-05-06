using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(new {value = "Simple"});
    }
}
