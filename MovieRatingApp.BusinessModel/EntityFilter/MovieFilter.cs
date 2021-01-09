using System.Collections.Generic;

namespace MovieRatingApp.BusinessModel.EntityFilter
{
    public class MovieFilter
    {
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public List<int> Genres { get; set; }
    }
}
