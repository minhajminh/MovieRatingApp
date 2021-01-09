using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRatingApp.BusinessModel;
using MovieRatingApp.BusinessModel.EntityFilter;
using MovieRatingApp.Core;
using System.Linq;

namespace MovieRatingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] MovieFilter filter)
        {
            if(string.IsNullOrEmpty(filter.Title) && filter.YearOfRelease == 0 && (filter.Genres == null || !filter.Genres.Any()))
                return BadRequest("At-least one filter is required");

            var result = _movieService.GetMovies(filter);

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Top5ByRating")]
        public IActionResult GetTop5ByRating()
        {
            var result = _movieService
                .GetTop5ByRating();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Top5ByUserRating")]
        public IActionResult GetTop5ByUserRating(int userId)
        {
            var result = _movieService
                .GetTop5ByUserRating(userId);

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpPost("Rating")]
        public IActionResult PostUserRating([FromBody] PostRatingRequestModel userRating)
        {
            var result = _movieService
                .PostRating(userRating);

            if (result == PostRatingResult.MovieNotFound || result == PostRatingResult.UserNotFound)
                return NotFound($"{(result == PostRatingResult.MovieNotFound ? "Movie" : "User")} Not Found");

            if (result == PostRatingResult.InvalidRating)
                return BadRequest("Invalid Rating");

            return Ok("User Rating Posted Successfully");
        }
    }
}
