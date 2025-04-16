namespace gregslist_dotnet.Models;
// NOTE cs:class code snippet!
public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public string Make { get; set; }
  public string Model { get; set; }
  // TODO show off data validation
  public int Year { get; set; }
  public string Color { get; set; }
  public int Price { get; set; }
  public int Mileage { get; set; }
  public string EngineType { get; set; }
  public string ImgUrl { get; set; }
  public bool HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
}