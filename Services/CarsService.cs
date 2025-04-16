
namespace gregslist_dotnet.Services;

public class CarsService
{
  public CarsService(CarsRepository carsRepository)
  {
    _carsRepository = carsRepository;
  }
  private readonly CarsRepository _carsRepository;


  internal List<Car> GetCars()
  {
    List<Car> cars = _carsRepository.GetCars();
    return cars;
  }
}