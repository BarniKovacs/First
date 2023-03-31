using System.ComponentModel.DataAnnotations;

namespace CityInfo.Entities
{
  public class PointOfInterest
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public City City { get; set; }
    public int CityId { get; set; }
  }
}
