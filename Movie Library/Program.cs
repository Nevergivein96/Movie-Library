using Microsoft.Extensions.Configuration;
using Movie_Library;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var movieRepo = new DapperMovieRepository(conn);
var movie = movieRepo.GetAllMovies();

foreach(var mov in movie)
{
    Console.WriteLine($"{mov.movieId} | {mov.movie_name} | {mov.rating} | {mov.genre} | {mov.rating_scale} | {mov.series_or_movie}");
}