using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CityInfo.Controllers
{
    [ApiController]
    [Route("api/PsOI")]
    public class PointOfImterestController : Controller
    {
        public static List<PointOfInterestDto>pointsOfInterest = new List<PointOfInterestDto> 
        {
            new PointOfInterestDto() {Id = 1, Name = "Central Park", City = "New York", Region = "Mid-Atlantic", Description = "The most famous urban park in the United States."},
            new PointOfInterestDto() {Id = 2, Name = "Eiffel Tower", City = "Paris", Region = "Île-de-France", Description = "A wrought-iron lattice tower on the Champ de Mars in Paris, France."},
            new PointOfInterestDto() {Id = 3, Name = "Big Ben", City = "London", Region = "London", Description = "The nickname for the Great Bell of the clock at the north end of the Palace of Westminster in London."},
            new PointOfInterestDto() {Id = 4, Name = "Tokyo Tower", City = "Tokyo", Region = "Kantō", Description = "A communications and observation tower in the Shiba-koen district of Minato, Tokyo, Japan."},
            new PointOfInterestDto() {Id = 5, Name = "Empire State Building", City = "New York", Region = "Mid-Atlantic", Description = "The design for the Empire State Building was changed fifteen times until it was ensured to be the world's tallest building." }
        };

        //[HttpGet]
        //public IActionResult GetPointsOfInterest()
        //{
        //    return Ok(PointsOfInterest);
        //}
        //[HttpGet]
        //[Route("{id}")]
        //public ActionResult GetPointOfInterest(int id) { }

        [HttpGet]
        //public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest() 
        //{
        //    return (pointsOfInterest);
        //}

        public IActionResult GetPointsOfInterest() 
        {
            return Ok(pointsOfInterest);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPointOfInterest (int id) 
        {
            if (id > pointsOfInterest.Count) 
            {
                return BadRequest();
            }

            var pointOfInterest = pointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null) 
            {
                return NotFound();
            }
            return Ok(pointOfInterest);
        }
    }
}
