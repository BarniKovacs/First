using AutoMapper;
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
    private readonly IMapper _mapper;
    public CitiesController(CityInfoContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
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

      CityDto cityDto = _mapper.Map<CityDto>(city);

      //cityDto.PointsOfInterest = city.PointOfInterests;

      if (cityDto == null)
      {
        return BadRequest("Ilyen nincs!");
      }

      return Ok(cityDto);
    }

    [HttpPost]
    public IActionResult CreateCity([FromBody] CityDto cityDto)
    {
      City city = _mapper.Map<City>(cityDto);

      _ctx.Cities.Add(city);
      _ctx.SaveChanges();

      return Ok(_mapper.Map<List<CityDto>>(_ctx.Cities));
    }
  }
}
