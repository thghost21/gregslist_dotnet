
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

  internal House CreateHouse(House houseData)
  {
    House house = _housesRepository.CreateHouse(houseData);
    return house;
  }

  internal string DeleteHouse(int houseId, Account userInfo)
  {
    House house = GetHouseByID(houseId);
    if (userInfo.Id != house.CreatorId)
    {
      throw new Exception("stop it, get some help");
    }
    _housesRepository.DeleteHouse(houseId);
    return "house was deleted";
  }

  internal House UpdateHouse(int houseId, House houseData, Account userInfo)
  {
    House house = GetHouseByID(houseId);
    if (house.CreatorId != userInfo.Id)
    {
      throw new Exception("you cant edit a house you dont own");
    }
    house.Sqft = houseData.Sqft ?? house.Sqft;
    house.Bedrooms = houseData.Bedrooms ?? house.Bedrooms;
    house.Bathrooms = houseData.Bathrooms ?? house.Bathrooms;
    house.ImgUrl = houseData.ImgUrl ?? house.ImgUrl;
    house.Description = houseData.Description ?? house.Description;
    house.Price = houseData.Price ?? house.Price;

    _housesRepository.UpdateHouse(house);
    return house;
  }
}