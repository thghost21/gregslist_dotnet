
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
}