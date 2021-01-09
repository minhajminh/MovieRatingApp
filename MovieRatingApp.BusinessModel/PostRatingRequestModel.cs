namespace MovieRatingApp.BusinessModel
{
    public class PostRatingRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
    }
}
