using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
const string GetGameEndpointName = "GetGame";


private static readonly List<GameDto> games = [
    new (
        1,
        "Witcher 3",
        "RPG",
        15.99M,
        new DateOnly(2015,5,20)),

    new (
        2,
        "Cyberpunk 2077",
        "RPG",
        20.99M,
        new DateOnly(2015,5,20)),

    new (
        3,
        "Baldur's Gate 3",
        "RPG",
        15.99M,
        new DateOnly(2023,3,20)),

     new (
        4,
        "Gta V",
        "RPG",
        5.99M,
        new DateOnly(2014,6,20)),
    ];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games");

// GET /games
group.MapGet("/", () => games);

//GET /games/1

group.MapGet("/{id}", (int id) => 
{
    GameDto? game = games.Find(game => game.Id ==id);

    return game is null ? Results.NotFound() : Results.Ok(game);
})
    .WithName("GetGameEndpointName");

// POST /games
group.MapPost("/", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count +1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate);
    
    games.Add(game);
    return Results.CreatedAtRoute("GetGameEndpointName", new {id = game.Id}, game);
});

// PUT /games
group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
{   
    var index = games.FindIndex(game => game.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    games[index] = new GameDto(
        id,
        updateGame.Name,
        updateGame.Genre,
        updateGame.Price,
        updateGame.ReleaseDate
    );
    return Results.NoContent(); 
});

//DELETE /games/1
group.MapDelete("/{id}", (int id) =>
{
    games.RemoveAll(game => game.Id ==  id);

    return Results.NoContent();
    
});

return group;

}



}
