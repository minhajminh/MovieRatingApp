using MovieRatingApp.BusinessModel;
using MovieRatingApp.BusinessModel.EntityFilter;
using System.Collections.Generic;

namespace MovieRatingApp.Core
{
    public interface IMovieService
    {
        List<MovieBusinessModel> GetMovies(MovieFilter filter);
        List<MovieBusinessModel> GetTop5ByRating();
        List<MovieBusinessModel> GetTop5ByUserRating(int userId);
        PostRatingResult PostRating(PostRatingRequestModel userRating);
    }
}
