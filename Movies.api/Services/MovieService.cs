using Movies.api.DbContexts;
using Movies.api.Dto;
using Movies.api.Exceptions.Movie;
using Movies.api.Models;

namespace Movies.api.Services;
public class MovieService : IMovieService
{
    private readonly MoviesContext _dbContext;

    public MovieService(MoviesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddMovie(MovieRequest movie)
    {
        _dbContext.Movies.Add(new Movie
        {
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate
        });
        _dbContext.SaveChanges();
    }

    public void DeleteMovie(int id)
    {
        var movieToDelete = _dbContext.Movies.Find(id)
            ?? throw new MovieNotFoundException();

        _dbContext.Movies.Remove(movieToDelete);
        _dbContext.SaveChanges();
    }

    public Movie GetMovieById(int id)
    {
        var movie = _dbContext.Movies.Find(id)
            ?? throw new MovieNotFoundException();

        return movie;
    }

    public List<Movie> GetMovies()
    {
        return _dbContext.Movies.ToList();
    }

    public void UpdateMovie(int id, MovieRequest movie)
    {
        var movieToUpdate = _dbContext.Movies.Find(id)
            ?? throw new MovieNotFoundException();

        movieToUpdate.Title = movie.Title;
        movieToUpdate.Genre = movie.Genre;
        movieToUpdate.ReleaseDate = movie.ReleaseDate;

        _dbContext.SaveChanges();
    }
}