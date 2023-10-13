namespace Movies.api.Models;
public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }
}