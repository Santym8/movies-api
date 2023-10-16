namespace Movies.api.Models;
public class Director
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public ICollection<Movie> Movies { get; } = new List<Movie>();
}