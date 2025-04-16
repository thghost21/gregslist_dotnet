using System.ComponentModel.DataAnnotations;

namespace gregslist_dotnet.Models;
// NOTE cs:class code snippet!
public class Car
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  [MinLength(3), MaxLength(30)] public string Make { get; set; }
  public string Model { get; set; }

  [Range(1896, 2026)] public int Year { get; set; }
  public string Color { get; set; }
  // NOTE will default to null instead of 0 if no value is supplied
  public int? Price { get; set; }
  public int Mileage { get; set; }
  public string EngineType { get; set; }
  public string ImgUrl { get; set; }
  // NOTE will default to null instead of false if no value is supplied
  public bool? HasCleanTitle { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}