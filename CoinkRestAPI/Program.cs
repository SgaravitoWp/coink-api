using CoinkRestAPI.CORE.Interfaces;
using CoinkRestAPI.CORE.Services;
using CoinRestAPI.CORE.Services;
using CoinRestAPI.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>(); 

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
