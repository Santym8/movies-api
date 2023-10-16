using Microsoft.EntityFrameworkCore;
using Movies.api.DbContexts;
using Movies.api.Dto;
using Movies.api.Exceptions.Director;
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
        var director = _dbContext.Directors.Find(movie.DirectorId)
            ?? throw new DirectorNotFoundException();

        _dbContext.Movies.Add(new Movie
        {
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Director = director

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

    public MovieResponse GetMovieById(int id)
    {
        var movie = _dbContext.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == id)
            ?? throw new MovieNotFoundException();

        return new MovieResponse(
            movie.Id,
            movie.Title,
            movie.Genre,
            movie.ReleaseDate,
            movie.Director.Id
        );
    }

    public List<MovieResponse> GetMovies()
    {
        var movies = _dbContext.Movies.Include(m => m.Director).ToList();

        return movies.Select(movie => new MovieResponse(
            movie.Id,
            movie.Title,
            movie.Genre,
            movie.ReleaseDate,
            movie.Director.Id
        )).ToList();
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