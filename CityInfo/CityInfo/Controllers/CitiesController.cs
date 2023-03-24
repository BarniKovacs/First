using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.Controllers
{
  [ApiController]
  [Route("api/cities")]
  public class CitiesController : Controller
  {
    [HttpGet]
    public IActionResult GetCities()
    {
      //var CityDataStore = new CitiesDataStore();
      //List<CityDto> Cities = CityDataStore.Cities;

      List<CityDto> Cities = CitiesDataStore.Current.Cities;
      return Ok(Cities);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetCity(int id)
    {
      List<CityDto> Cities = CitiesDataStore.Current.Cities;
      CityDto city = Cities.Where(el => el.Id == id).FirstOrDefault();

      if (city == null)
      {
        return BadRequest("Ilyen nincs!");
      }

      return Ok(city);
    }

    [HttpPost]
    public IActionResult CreateCity([FromBody]CityDto city)
    {
      city.Id = 4;

      List<CityDto> Cities = CitiesDataStore.Current.Cities;
      Cities.Add(city);

      return Ok(Cities);
    }
  }
}
