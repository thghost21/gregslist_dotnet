


namespace gregslist_dotnet.Repositories;

public class CarsRepository
{
  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;


  internal List<Car> GetCars()
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.*
    FROM cars
    INNER JOIN accounts ON accounts.id = cars.creator_id;";

    List<Car> cars = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }).ToList();

    return cars;
  }

  internal Car GetCarById(int carId)
  {
    string sql = @"
    SELECT 
    cars.*,
    accounts.*
    FROM cars
    INNER JOIN accounts ON accounts.id = cars.creator_id
    WHERE cars.id = @carId;";

    Car foundCar = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, new { carId }).SingleOrDefault();
    return foundCar;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO 
    cars (make, model, year, price, color, mileage, engine_type, img_url, has_clean_title, creator_id)
    VALUES (@Make, @Model, @Year, @Price, @Color, @Mileage, @EngineType, @ImgUrl, @HasCleanTitle, @CreatorId);
    
    SELECT
    cars.*,
    accounts.*
    FROM cars
    INNER JOIN accounts ON accounts.id = cars.creator_id 
    WHERE cars.id = LAST_INSERT_ID();";

    Car createdCar = _db.Query(sql, (Car car, Account account) =>
    {
      car.Creator = account;
      return car;
    }, carData).SingleOrDefault();

    return createdCar;
  }
}