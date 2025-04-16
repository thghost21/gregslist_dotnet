

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

  internal Car GetCarById(int carId)
  {
    Car car = _carsRepository.GetCarById(carId);
    if (car == null)
    {
      throw new Exception($"No car found with the id of {carId}");
    }
    return car;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _carsRepository.CreateCar(carData);
    return car;
  }

  internal string DeleteCar(int carId, Account userInfo)
  {
    Car car = GetCarById(carId);

    if (car.CreatorId != userInfo.Id)
    {
      throw new Exception($"YOU ARE NOT ALLOWED TO DELETE SOMEONE ELSE'S CAR, {userInfo.Name.ToUpper()}!");
    }

    _carsRepository.DeleteCar(carId);

    return $"Your {car.Make} {car.Model} has been deleted!";
  }
}