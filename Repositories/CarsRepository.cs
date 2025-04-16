
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
    string sql = "SELECT * FROM cars;";

    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }
}