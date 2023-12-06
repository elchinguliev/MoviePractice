using Homework123.Data;
using Homework123.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework123.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDBContext _dbContext;

        public MoviesController(MovieDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return Ok(movies);
        }
    }
}
