using Movies.api.Dto;
using Movies.api.Models;

namespace Movies.api.Services;
public interface IMovieService
{
    List<Movie> GetMovies();
    Movie GetMovieById(int id);
    void DeleteMovie(int id);
    void AddMovie(MovieRequest movie);
    void UpdateMovie(int id, MovieRequest movie);

}