using Booking.DataRepositories.RepositoryImplementor;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;
using Booking.Service.Managers;
using MovieBookingService.Interfaces;
using MovieBookingService.Managers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddSingleton<IMovieBookingManager, MovieBookingManager>();
builder.Services.AddSingleton<IMovieManager, MovieManager>();
builder.Services.AddSingleton<IMovieTheatreManager, MovieTheatreManager>();
builder.Services.AddSingleton<IScreeningRoomManager, ScreeningRoomManager>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
builder.Services.AddSingleton<IMovieTheatreRepository, MovieTheatreRepository>();
builder.Services.AddSingleton<IScreeningRoomRepository, ScreeningRoomRepository>();
builder.Services.AddSingleton<IBookingDetailsRepository, BookingDetailsRepository>();

builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
