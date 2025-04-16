



namespace gregslist_dotnet.Repositories;

public class HousesRepository
{
  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal List<House> GetAllHouses()
  {
    string sql = @"
    SELECT
    houses.*,
    accounts.*
    FROM houses
    INNER JOIN accounts ON accounts.id = houses.creator_id;";

    List<House> houses = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();
    return houses;
  }

  internal House GetHouseById(int houseId)
  {
    string sql = @"
    SELECT 
    houses.*,
    accounts.*
    FROM houses
    INNER JOIN accounts ON accounts.id = houses.creator_id
    WHERE houses.id = @houseId;";

    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).SingleOrDefault();
    return house;
  }

  internal House CreateHouse(House houseData)
  {
    string sql = @"
    INSERT INTO
    houses (sqft, bedrooms, bathrooms, img_url, description, price, creator_id)
    VALUES(@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price, @CreatorId);

    SELECT
    houses.*,
    accounts.*
    From houses
    INNER JOIN accounts on accounts.id = houses.creator_id
    WHERE houses.id = LAST_INSERT_ID();";

    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, houseData).SingleOrDefault();
    return house;
  }

  internal void DeleteHouse(int houseId)
  {
    string sql = @"DELETE FROM houses WHERE id = @houseId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { houseId });
    if (rowsAffected == 0)
    {
      throw new Exception("that didn't work");
    }
    if (rowsAffected > 1)
    {
      throw new Exception("whoops thats even worse");
    }
  }

  internal void UpdateHouse(House house)
  {
    string sql = @"
    UPDATE houses
    SET
    sqft = @Sqft,
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    img_url = @ImgUrl,
    description = @Description,
    price = @Price
    WHERE id = @Id
    LIMIT 1;";

    int rowsAffected = _db.Execute(sql, house);
    if (rowsAffected == 0)
    {
      throw new Exception("no rows updated");
    }

    if (rowsAffected > 1)
    {
      throw new Exception("WHOOPS");
    }
  }
}