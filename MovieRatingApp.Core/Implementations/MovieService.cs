using MovieRatingApp.BusinessModel;
using MovieRatingApp.BusinessModel.EntityFilter;
using MovieRatingApp.DataAccess;
using MovieRatingApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieRatingApp.Core.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _dbContext;
        public MovieService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<MovieBusinessModel> GetMovies(MovieFilter filter)
        {
            var allMovies = _dbContext.Movies.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Title))
                {
                    allMovies = allMovies
                        .Where(m => m.Title.Contains(filter.Title));
                }

                if (filter.YearOfRelease > 0)
                {
                    allMovies = allMovies
                        .Where(m => m.YearOfRelease == filter.YearOfRelease);
                }

                if (filter.Genres != null && filter.Genres.Any())
                {
                    allMovies = allMovies
                        .Where(m => m.MovieGenres.Any(mg=> filter.Genres.Any(g=> g == mg.GenreId)));
                }
            }

            return allMovies.Select(m=>new MovieBusinessModel()
            {
                Id = m.Id,
                Title = m.Title,
                RunningTimeSpan = m.RunningTime,
                YearOfRelease = m.YearOfRelease,
                Genres = m.MovieGenres.Select(g=>g.Genre.GenreName).ToList(),
                AverageRatingValue = m.UserRatings.Sum(r => r.Rating) /
                                     (m.UserRatings.Count == 0 ? 1 : m.UserRatings.Count),
            })
            .ToList();
        }

        public List<MovieBusinessModel> GetTop5ByRating()
        {
            var allMovies = _dbContext.Movies.AsQueryable();

            return allMovies.
                OrderByDescending(m =>
                    m.UserRatings.Sum(r => r.Rating) / (m.UserRatings.Count == 0 ? 1 : m.UserRatings.Count))
                .Select(m => new MovieBusinessModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    RunningTimeSpan = m.RunningTime,
                    YearOfRelease = m.YearOfRelease,
                    Genres = m.MovieGenres.Select(g => g.Genre.GenreName).ToList(),
                    AverageRatingValue = m.UserRatings.Sum(r => r.Rating) /
                                         (m.UserRatings.Count == 0 ? 1 : m.UserRatings.Count)
                })
                .Take(5)
                .ToList();
        }

        public List<MovieBusinessModel> GetTop5ByUserRating(int userId)
        {
            var allMovies = _dbContext.Movies.AsQueryable();

            return allMovies
                .OrderByDescending(m => m.UserRatings
                        .Where(ur=>ur.UserId==userId).Sum(r => r.Rating) / 
                                (m.UserRatings.Where(ur => ur.UserId == userId).Count() == 0 ? 1 : m.UserRatings.Where(ur => ur.UserId == userId).Count()))
                .Select(m => new MovieBusinessModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    RunningTimeSpan = m.RunningTime,
                    YearOfRelease = m.YearOfRelease,
                    Genres = m.MovieGenres.Select(g => g.Genre.GenreName).ToList(),
                    AverageRatingValue = m.UserRatings.Sum(r => r.Rating) /
                                         (m.UserRatings.Count == 0 ? 1 : m.UserRatings.Count)
                })
                .Take(5)
                .ToList();
        }

        public PostRatingResult PostRating(PostRatingRequestModel userRating)
        {
            var movieExists = _dbContext.Movies.Any(m => m.Id == userRating.MovieId);
            var userExists = _dbContext.Users.Any(m => m.Id == userRating.UserId);

            if (!movieExists) 
                return PostRatingResult.MovieNotFound;

            if (!userExists) 
                return PostRatingResult.UserNotFound;

            if (userRating.Rating < 1 || userRating.Rating > 5) 
                return PostRatingResult.InvalidRating;

            var userRatingObject = _dbContext
                .UserRatings
                .Where(ur => ur.UserId == userRating.UserId && ur.MovieId == userRating.MovieId)
                .FirstOrDefault();
            
            if(userRatingObject == null)
            {
                _dbContext
                    .UserRatings
                    .Add(new UserRating
                    {
                        UserId = userRating.UserId,
                        MovieId = userRating.MovieId,
                        Rating = userRating.Rating
                    });
            }
            else
            {
                userRatingObject.Rating = userRating.Rating;
            }

            _dbContext.SaveChanges();

            return PostRatingResult.Success;
        }
    }
}
