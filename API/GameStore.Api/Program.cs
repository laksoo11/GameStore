using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);


var app = builder.Build();

app.MapGamesEndpoints();
app.MapGenresEndpoints();

app.MapGet("/", () => "GameStore API is running!");

await app.MigrateDbAsync();

app.Run();

