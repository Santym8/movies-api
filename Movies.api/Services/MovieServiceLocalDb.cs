using Movies.api.Dto;
using Movies.api.Models;

namespace Movies.api.Services;
public class MovieServiceLocalDb : IMovieService
{
    private static readonly List<Movie> dataBaseMovies = new(){
        new Movie { Id = 0, Title = "Star Wars", Genre = "Sci-Fi", ReleaseDate = new DateTime(1977, 5, 25) },
        new Movie { Id = 1, Title = "The Empire Strikes Back", Genre = "Sci-Fi", ReleaseDate = new DateTime(1980, 5, 21) },
        new Movie { Id = 2, Title = "Return of the Jedi", Genre = "Sci-Fi", ReleaseDate = new DateTime(1983, 5, 25) },
    };

    public void AddMovie(MovieRequest movie)
    {
        var newMovie = new Movie
        {
            Id = dataBaseMovies.Max(m => m.Id) + 1,
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate
        };
        dataBaseMovies.Add(newMovie);
    }

    public void DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        dataBaseMovies.Remove(movie);
    }

    public Movie GetMovieById(int id)
    {
        return dataBaseMovies.FirstOrDefault(m => m.Id == id);
    }

    public List<Movie> GetMovies()
    {
        return dataBaseMovies;
    }

    public void UpdateMovie(int id, MovieRequest movie)
    {
        var movieToUpdate = GetMovieById(id);
        if (movieToUpdate is not null)
        {
            movieToUpdate.Title = movie.Title;
            movieToUpdate.Genre = movie.Genre;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
        }
    }
}