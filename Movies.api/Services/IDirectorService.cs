using Movies.api.Dto;
using Movies.api.Models;

namespace Movies.api.Services;
public interface IDirectorService
{
    DirectorResponse CreateDirector(DirectorRequest request);
    DirectorResponse GetDirectorById(int id);
    
}