using Homework123.Data;
using Homework123.Entities;
using Homework123.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework123.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IGetMovieService movieGetService;
        private readonly IMovieService _movieService;

        public MovieController(IGetMovieService movieGetServices, IMovieService movieService)
        {
            movieGetService = movieGetServices;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            int waitTimeInSeconds = 5;
            while (true)
            {

            await Task.Delay(TimeSpan.FromSeconds(waitTimeInSeconds));

            var result = await movieGetService.GetMovieFromApi();
            var movie = _movieService.GetAll().FirstOrDefault(m => m.Title == result.Title);
                if (movie == null)
                {
                    _movieService.Add(result);
                }
            }
        }
    }

}
