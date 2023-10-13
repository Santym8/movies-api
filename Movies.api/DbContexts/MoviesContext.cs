using Microsoft.EntityFrameworkCore;
using Movies.api.Models;

namespace Movies.api.DbContexts;
public class MoviesContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    public MoviesContext(DbContextOptions<MoviesContext> configuration)
        : base(configuration)
    { }


}