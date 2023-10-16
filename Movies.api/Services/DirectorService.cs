using Microsoft.EntityFrameworkCore;
using Movies.api.DbContexts;
using Movies.api.Dto;
using Movies.api.Exceptions.Director;
using Movies.api.Models;

namespace Movies.api.Services;
public class DirectorService : IDirectorService
{
    private readonly MoviesContext _context;

    public DirectorService(MoviesContext context)
    {
        _context = context;
    }

    public DirectorResponse CreateDirector(DirectorRequest request)
    {
        var director = new Director
        {
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var directorAdded = _context.Directors.Add(director);
        _context.SaveChangesAsync();

        return new DirectorResponse(
            directorAdded.Entity.Id,
            directorAdded.Entity.FirstName,
            directorAdded.Entity.LastName,
            directorAdded.Entity.Movies.Select(m => m.Id).ToList()
        );
    }

    public DirectorResponse GetDirectorById(int id)
    {
        var director = _context.Directors.Include(d => d.Movies).FirstOrDefault(d => d.Id == id)
            ?? throw new DirectorNotFoundException();

        return new DirectorResponse(
            director.Id,
            director.FirstName,
            director.LastName,
            director.Movies.Select(m => m.Id).ToList()
        );
    }
}