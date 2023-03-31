using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CityInfo.Controllers
{
  [ApiController]
  [Route("api/cities/{cityId}/pointsofinterest")]
  public class PointsOfInterestController : Controller
  {
    [HttpGet(Name = "GetPointsOfInterest")]
    public IActionResult GetPointsOfInterest(int cityId)
    {
      var city = CitiesDataStore.Current.Cities.Where(el => el.Id == cityId).FirstOrDefault();

      if (city == null) { return NotFound("City not found"); }

      return Ok(city.PointsOfInterest);
    }

    [HttpGet("{id}", Name = "GetPointOfInterest")]
    public IActionResult GetPointOfInterestById(int cityId, int id)
    {
      var city = CitiesDataStore.Current.Cities.Where(el => el.Id == cityId).FirstOrDefault();

      if (city == null) { return NotFound("City not found"); }

      var pointOfInterest = city.PointsOfInterest.FirstOrDefault(el => el.Id == id);

      if (pointOfInterest == null)
      {
        return NotFound("Point of Interest not found");
      }

      return Ok(pointOfInterest);
    }

    [HttpPost]
    public IActionResult CreatePointOfInterest(int cityId,
           [FromBody] PointOfInterestDto pointOfInterest)
    {
      var city = CitiesDataStore.Current.Cities.Where(el => el.Id == cityId).FirstOrDefault();

      if (city == null) { return NotFound("City not found"); }

      if (pointOfInterest.Description == pointOfInterest.Name)
      {
        ModelState.AddModelError(
          "Description",
          "The provided description should be different from the name.");

        ModelState.AddModelError(
          "Description",
          "Too Short description");

        ModelState.AddModelError(
          "Name",
          "The provided description should be different from the description.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                                    c => c.PointsOfInterest).Max(p => p.Id);
      pointOfInterest.Id = ++maxPointOfInterestId;

      city.PointsOfInterest.Add(pointOfInterest);

      return CreatedAtRoute(
        "GetPointOfInterest",
        new { cityId, id = pointOfInterest.Id });
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePointOfInterest(int cityId, int id,
    [FromBody] PointOfInterestDto pointOfInterest)
    {
      if (pointOfInterest.Description == pointOfInterest.Name)
      {
        ModelState.AddModelError(
            "Description",
            "The provided description should be different from the name.");
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }

      var pointOfInterestFromStore = city.PointsOfInterest
          .FirstOrDefault(p => p.Id == id);
      if (pointOfInterest == null)
      {
        return NotFound();
      }

      pointOfInterestFromStore.Name = pointOfInterest.Name;
      pointOfInterestFromStore.Description = pointOfInterest.Description;

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePointOfInterest(int cityId, int id)
    {
      var city = CitiesDataStore.Current.Cities
          .FirstOrDefault(c => c.Id == cityId);
      if (city == null)
      {
        return NotFound();
      }

      var pointOfInterestFromStore = city.PointsOfInterest
          .FirstOrDefault(c => c.Id == id);
      if (pointOfInterestFromStore == null)
      {
        return NotFound();
      }

      city.PointsOfInterest.Remove(pointOfInterestFromStore);

      return NoContent();
    }
  }
}
