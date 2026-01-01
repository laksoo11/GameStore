namespace GameStore.Api.Dtos;

public record class CreateGameDto(
    string Id,
    string Name,
    string Genre, 
    decimal Price, 
    DateOnly ReleaseDate
);

