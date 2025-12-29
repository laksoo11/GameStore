using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{

    private readonly List <GameSummary> games = 

    [
    new (){
        Id = 1,
        Name = "Witcher 3",
        Genre = "Fantasy RPG",
        Price = 15.99M,
        ReleaseDate = new DateOnly(2015,5,20)
        
    },

     new (){
        Id = 2,
        Name = "Cyberpunk 2077",
        Genre = "Future RPG",
        Price = 20.99M,
        ReleaseDate = new DateOnly(2020,9,20)},

     new (){
        Id = 3,
        Name = "Baldur's Gate 3",
        Genre = "Fantasy RPG",
        Price = 15.99M,
        ReleaseDate = new DateOnly(2023,3,20)},

    new (){
        Id = 4,
        Name = "GTA V",
        Genre = "RPG",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2014,6,20)},

    new (){
        Id = 5,
        Name = "God Of War",
        Genre = "RPG",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2018,3,22)},

     new (){
        Id = 6,
        Name = "Elden Ring",
        Genre = "RPG, Boss Fight, Fighiting",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2022,11,22)}, 

    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)

    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);

        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,

        };

        games.Add(gameSummary);
    }



}
