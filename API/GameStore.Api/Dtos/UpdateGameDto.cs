namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
    string Id,
    string Name,
    string Genre, 
    decimal Price, 
    DateOnly ReleaseDate
);

