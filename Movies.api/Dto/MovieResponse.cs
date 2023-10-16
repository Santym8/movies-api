using Movies.api.Models;

namespace Movies.api.Dto;
public record MovieResponse(
    int Id,
    string Title,
    string Genre,
    DateTime ReleaseDate,
    int DirectorId
);