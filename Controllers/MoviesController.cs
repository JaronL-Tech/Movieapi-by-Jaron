using Microsoft.AspNetCore.Mvc;
using Movieslabapi.Data;
using Movieslabapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movieslabapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDBcontext _context;

        public MoviesController(ApplicationDBcontext context)
        {
            _context = context;
        }
        
        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            var Movies = _context.Movies.ToList();
            return Ok(Movies);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Music = _context.Movies.Find(id);
            if (Music == null)
            {
                return NotFound();
            }
            return Ok(Music);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie Movie)
        {
            _context.Movies.Add(Movie);
            _context.SaveChanges();
            return StatusCode(201, Movie);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie UpdateMovie)
        {
            var Movie = _context.Movies.Find(id);
            if (Movie == null)
            {
                return NotFound();
            }
            Movie.Title = UpdateMovie.Title;
            Movie.RunningTime = UpdateMovie.RunningTime;
            Movie.Genre = UpdateMovie.Genre;

            _context.Update(Movie);
            _context.SaveChanges();
            return StatusCode(201, Movie);
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {
            var Movie = _context.Movies.Find(id);
            if (Movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(Movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
