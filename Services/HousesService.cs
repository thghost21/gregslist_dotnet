
using Microsoft.AspNetCore.Http.HttpResults;

namespace gregslist_dotnet.Services;

public class HousesService
{
  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }
  private readonly HousesRepository _housesRepository;

  internal List<House> GetAllHouses()
  {
    List<House> houses = _housesRepository.GetAllHouses();
    return houses;
  }

  internal House GetHouseByID(int houseId)
  {
    House house = _housesRepository.GetHouseById(houseId);
    if (house == null)
    {
      throw new Exception($"No house with the Id of {houseId}");
    }
    return house;
  }
}