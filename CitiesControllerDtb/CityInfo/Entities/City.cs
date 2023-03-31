using CityInfo.Models;
using System.Collections.Generic;

namespace CityInfo.Entities
{
  public class City
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<PointOfInterest> PointsOfInterest { get; set; }
  }
}
