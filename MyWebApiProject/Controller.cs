[ApiController]
[Route("api")]
public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        return Ok("Hello, World!");
    }
}
