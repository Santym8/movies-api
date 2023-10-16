using Movies.api.Dto;
namespace Movies.api.Services;
public interface IMovieService
{
    List<MovieResponse> GetMovies();
    MovieResponse GetMovieById(int id);
    void DeleteMovie(int id);
    void AddMovie(MovieRequest movie);
    void UpdateMovie(int id, MovieRequest movie);

}