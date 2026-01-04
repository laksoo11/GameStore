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
        Genre = "RPG",
        Price = 15.99M,
        ReleaseDate = new DateOnly(2015,5,20)
        
    },

    new (){
        Id = 2,
        Name = "Cyberpunk 2077",
        Genre = "RPG",
        Price = 20.99M,
        ReleaseDate = new DateOnly(2020,9,20)
    },

    new (){
        Id = 3,
        Name = "Baldur's Gate 3",
        Genre = "RPG",
        Price = 15.99M,
        ReleaseDate = new DateOnly(2023,3,20)},

    new (){
        Id = 4,
        Name = "WWE",
        Genre = "Fighting",
        Price = 9.99M,
        ReleaseDate = new DateOnly(2018,3,10)},

    new (){
        Id = 5,
        Name = "God Of War",
        Genre = "RPG",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2018,3,22)},

    new (){
        Id = 6,
        Name = "Elden Ring",
        Genre = "RPG",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2022,11,22)}, 

    new (){
        Id = 7,
        Name = "Fifa 11",
        Genre = "Sports",
        Price = 5.99M,
        ReleaseDate = new DateOnly(2011,11,22)}, 

    new (){
        Id = 8,
        Name = "Clash Of Clans",
        Genre = "Strategy",
        Price = 1M,
        ReleaseDate = new DateOnly(2010,05,10)},

    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)

    {
        Genre genre = GetGenreById(game.GenreId);

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

   
        

    public GameDetails GetGame(int id)

    {
        GameSummary? game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
             genre.Name,
             game.Genre,
             StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,

        };
    }



    public void UpdateGame(GameDetails updatedGame)

    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existinGame = GetGameSummaryById(updatedGame.Id);

        existinGame.Name = updatedGame.Name;
        existinGame.Genre = genre.Name;
        existinGame.Price = updatedGame.Price;
        existinGame.ReleaseDate = updatedGame.ReleaseDate;


    }

    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
        
    }



    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }

}
