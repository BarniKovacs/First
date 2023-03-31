using CityInfo.Contexts;
using CityInfo.Entities;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.Controllers
{
  [ApiController]
  [Route("api/cities")]
  public class CitiesController : Controller
  {
    private readonly CityInfoContext _ctx;
    public CitiesController(CityInfoContext ctx) 
        {
            _ctx = ctx; 
        }

    [HttpGet]
    public IActionResult GetCities()
    {
      //var CityDataStore = new CitiesDataStore();
      //List<CityDto> Cities = CityDataStore.Cities;

      DbSet<City> Cities = _ctx.Cities;
      return Ok(Cities);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetCity(int id)
    {
      //DbSet<City> Cities = _ctx.Cities;
      //City city = Cities.Where(el => el.Id == id).FirstOrDefault();

      City city = _ctx.Cities.Where(el => el.Id == id).FirstOrDefault();

            if (city == null)
      {
        return BadRequest("Ilyen nincs!");
      }

      return Ok(city);
    }

    [HttpPost]
    public IActionResult CreateCity([FromBody]City city)
    {
      //city.Id = 4;

      //List<CityDto> Cities = CitiesDataStore.Current.Cities;
      //Cities.Add(city);

      _ctx.Cities.Add(city);
      _ctx.SaveChanges();

      return Ok(_ctx.Cities);
    }
  }
}
