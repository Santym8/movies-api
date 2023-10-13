namespace Movies.api.Dto;
public record MovieRequest(
    string Title,
    string Genre,
    DateTime ReleaseDate
);
