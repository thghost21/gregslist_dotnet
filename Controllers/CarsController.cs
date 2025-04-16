namespace gregslist_dotnet.Controllers;

// NOTE cs:api_controller

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  [HttpGet]
  public string Test()
  {
    return "Cars Controller works!";
  }
}