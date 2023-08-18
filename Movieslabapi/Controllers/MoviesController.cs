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
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
