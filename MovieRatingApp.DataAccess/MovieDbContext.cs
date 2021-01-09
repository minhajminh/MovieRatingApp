using Microsoft.EntityFrameworkCore;
using MovieRatingApp.Entities;
using System;

namespace MovieRatingApp.DataAccess
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRating>()
                .HasIndex(p => new { p.UserId, p.MovieId })
                .IsUnique();

            modelBuilder.Entity<User>().HasData(new User() { Id = 1, UserName = "Min" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 2, UserName = "William" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 3, UserName = "Michael" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 4, UserName = "Joseph" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 5, UserName = "Charles" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 6, UserName = "Daniel" });
            modelBuilder.Entity<User>().HasData(new User() { Id = 7, UserName = "Anthony" });

            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 1, GenreName = "Action" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 2, GenreName = "Horror" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 3, GenreName = "Animation" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 4, GenreName = "Drama" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 5, GenreName = "Comedy" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 6, GenreName = "Thriller" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 7, GenreName = "Romance" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 8, GenreName = "Crime" });
            modelBuilder.Entity<Genre>().HasData(new Genre() { Id = 9, GenreName = "Adventure" });

            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 1, Title = "The Outpost", YearOfRelease = 2020, RunningTime = new TimeSpan(2, 3, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 2, Title = "Onward", YearOfRelease = 2020, RunningTime = new TimeSpan(2, 36, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 3, Title = "The Invisible Man", YearOfRelease = 2020, RunningTime = new TimeSpan(2, 5, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 4, Title = "Little Women", YearOfRelease = 2020, RunningTime = new TimeSpan(2, 15, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 5, Title = "Birds Of Prey", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 49, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 6, Title = "The Gentlemen", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 55, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 7, Title = "Trolls World Tour", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 30, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 8, Title = "The Witches", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 46, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 9, Title = "Greenland", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 59, 0) });
            modelBuilder.Entity<Movie>().HasData(new Movie() { Id = 10, Title = "Relic", YearOfRelease = 2020, RunningTime = new TimeSpan(1, 29, 0) });

            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 1, MovieId = 1, GenreId = 1 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 2, MovieId = 1, GenreId = 4 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 3, MovieId = 2, GenreId = 3 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 4, MovieId = 2, GenreId = 5 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 5, MovieId = 3, GenreId = 2 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 6, MovieId = 3, GenreId = 6 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 7, MovieId = 4, GenreId = 4 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 8, MovieId = 4, GenreId = 7 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 9, MovieId = 5, GenreId = 4 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 10, MovieId = 5, GenreId = 7 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 11, MovieId = 6, GenreId = 1 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 12, MovieId = 6, GenreId = 8 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 13, MovieId = 7, GenreId = 5 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 14, MovieId = 7, GenreId = 9 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 15, MovieId = 8, GenreId = 9 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 16, MovieId = 8, GenreId = 5 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 17, MovieId = 9, GenreId = 1 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 18, MovieId = 9, GenreId = 6 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 19, MovieId = 10, GenreId = 4 });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre() { Id = 20, MovieId = 10, GenreId = 2 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 1, MovieId = 1, UserId = 1, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 2, MovieId = 1, UserId = 2, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 3, MovieId = 1, UserId = 3, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 4, MovieId = 1, UserId = 4, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 5, MovieId = 1, UserId = 5, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 6, MovieId = 1, UserId = 6, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 7, MovieId = 1, UserId = 7, Rating = 4 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 8, MovieId = 2, UserId = 1, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 9, MovieId = 2, UserId = 2, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 10, MovieId = 2, UserId = 3, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 11, MovieId = 2, UserId = 4, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 12, MovieId = 2, UserId = 5, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 13, MovieId = 2, UserId = 6, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 14, MovieId = 2, UserId = 7, Rating = 3 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 15, MovieId = 3, UserId = 1, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 16, MovieId = 3, UserId = 2, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 17, MovieId = 3, UserId = 3, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 18, MovieId = 3, UserId = 4, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 19, MovieId = 3, UserId = 5, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 20, MovieId = 3, UserId = 6, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 21, MovieId = 3, UserId = 7, Rating = 3 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 22, MovieId = 4, UserId = 1, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 23, MovieId = 4, UserId = 2, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 24, MovieId = 4, UserId = 3, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 25, MovieId = 4, UserId = 4, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 26, MovieId = 4, UserId = 5, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 27, MovieId = 4, UserId = 6, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 28, MovieId = 4, UserId = 7, Rating = 1 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 29, MovieId = 5, UserId = 1, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 30, MovieId = 5, UserId = 2, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 31, MovieId = 5, UserId = 3, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 32, MovieId = 5, UserId = 4, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 33, MovieId = 5, UserId = 5, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 34, MovieId = 5, UserId = 6, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 35, MovieId = 5, UserId = 7, Rating = 1 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 36, MovieId = 6, UserId = 1, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 37, MovieId = 6, UserId = 2, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 38, MovieId = 6, UserId = 3, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 39, MovieId = 6, UserId = 4, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 40, MovieId = 6, UserId = 5, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 41, MovieId = 6, UserId = 6, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 42, MovieId = 6, UserId = 7, Rating = 3 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 43, MovieId = 7, UserId = 1, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 44, MovieId = 7, UserId = 2, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 45, MovieId = 7, UserId = 3, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 46, MovieId = 7, UserId = 4, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 47, MovieId = 7, UserId = 5, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 48, MovieId = 7, UserId = 6, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 49, MovieId = 7, UserId = 7, Rating = 3 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 50, MovieId = 8, UserId = 1, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 51, MovieId = 8, UserId = 2, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 52, MovieId = 8, UserId = 3, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 53, MovieId = 8, UserId = 4, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 54, MovieId = 8, UserId = 5, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 55, MovieId = 8, UserId = 6, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 56, MovieId = 8, UserId = 7, Rating = 3 });

            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 57, MovieId = 9, UserId = 1, Rating = 3 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 58, MovieId = 9, UserId = 2, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 59, MovieId = 9, UserId = 3, Rating = 2 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 60, MovieId = 9, UserId = 4, Rating = 1 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 61, MovieId = 9, UserId = 5, Rating = 4 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 62, MovieId = 9, UserId = 6, Rating = 5 });
            modelBuilder.Entity<UserRating>().HasData(new UserRating() { Id = 63, MovieId = 9, UserId = 7, Rating = 3 });
        }
    }
}
