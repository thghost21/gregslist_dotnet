using System.Threading.Tasks;

namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  public HousesController(HousesService housesService, Auth0Provider auth0Provider)
  {
    _housesService = housesService;
    _auth0Provider = auth0Provider;
  }
  private readonly HousesService _housesService;
  private readonly Auth0Provider _auth0Provider;


  [HttpGet]
  public ActionResult<List<House>> GetAllHouses()
  {
    try
    {
      List<House> houses = _housesService.GetAllHouses();
      return Ok(houses);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [HttpGet("{houseId}")]
  public ActionResult<House> GetHouseById(int houseId)
  {
    try
    {
      House house = _housesService.GetHouseByID(houseId);
      return Ok(house);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [Authorize]
  [HttpPost]
  public async Task<ActionResult<House>> CreateHouse([FromBody] House houseData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      houseData.CreatorId = userInfo.Id;
      House house = _housesService.CreateHouse(houseData);
      return house;
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [Authorize]
  [HttpDelete("{houseId}")]
  public async Task<ActionResult<House>> DeleteHouse(int houseId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _housesService.DeleteHouse(houseId, userInfo);
      return Ok(message);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
  [Authorize]
  [HttpPut("{houseId}")]
  public async Task<ActionResult<House>> UpdateHouse(int houseId, [FromBody] House houseData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      House house = _housesService.UpdateHouse(houseId, houseData, userInfo);
      return Ok(house);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }


}