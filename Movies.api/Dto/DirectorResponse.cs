namespace Movies.api.Dto;
public record DirectorResponse(
    int Id,
    string FirstName,
    string LastName,
    ICollection<int> MoviesId
);
