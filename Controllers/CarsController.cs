namespace gregslist_dotnet.Controllers;

// NOTE cs:api_controller

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }

  private readonly CarsService _carsService;


  [HttpGet]
  public ActionResult<List<Car>> GetAllCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{carId}")]
  public ActionResult<Car> GetCarById(int carId)
  {
    try
    {
      Car car = _carsService.GetCarById(carId);
      return Ok(car);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}