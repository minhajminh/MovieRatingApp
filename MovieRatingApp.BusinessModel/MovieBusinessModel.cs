using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieRatingApp.BusinessModel
{
    public class MovieBusinessModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        [JsonIgnore]
        public TimeSpan RunningTimeSpan { get; set; }
        public string RunningTime => new DateTime(RunningTimeSpan.Ticks).ToString("HH:mm:ss");
        public List<string> Genres { get; set; }
        [JsonIgnore]
        public decimal AverageRatingValue { get; set; }
        public decimal AverageRating => Math.Round((Math.Round(AverageRatingValue, 3) + 0.001m) * 2) / 2;
    }
}
