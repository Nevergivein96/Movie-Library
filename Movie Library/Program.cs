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

//Added a movie and deleted a movie
//movieRepo.InsertMovie("John Wick", "R", "Action, Thriller, Adventure", 10, "Movie Series");
//movieRepo.DeleteMovie();
string textToEnter = "Welcome To Your Movie Library!!!!";
Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", "Welcome To Your Movie Library!!!!"));
string textToEnter2 = "-----------------------------------";
Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter2.Length / 2)) + "}", ("-----------------------------------")));
Thread.Sleep(1000);
Console.WriteLine("What Would You Like To Do Today?");
Console.WriteLine("--------------------------------");
Thread.Sleep(1000);



var exit = true;
do
{
    Console.WriteLine("View Library - 'view' | Add To Library - 'add' | Delete From Library - 'delete' | Exit Program - 'exit'");
    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
    var userInput = Console.ReadLine();
    if (userInput.ToLower() == "exit")
    {
        exit = false;
        break;
    }
    if(userInput.ToLower() == "view")
    {
        var movie = movieRepo.GetAllMovies();
        foreach (var mov in movie)
        {
            Console.WriteLine($"{mov.movieId} | {mov.movie_name} | {mov.rating} | {mov.genre} | {mov.rating_scale} | {mov.series_or_movie}");
            Console.WriteLine("");
        }
    }
    if(userInput.ToLower() == "add")
    {
        Console.WriteLine("'Movie Name' | 'Movie Rating' | 'Genre' | 'How Much You Like It 1-10' | Is It A Series Or A Movie Or Both");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("What Is The Movie Name?");
        var movieName = Console.ReadLine();
        Console.WriteLine("What Is The Movie Rating?");
        var movieRating = Console.ReadLine();
        Console.WriteLine("What Is The Genre?");
        var genre = Console.ReadLine();
        Console.WriteLine("How Much Do You Like It On A Scale Of 1-10");
        var ratingScale = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Is It A Series Or A Movie Or Both");
        var series_or_movie = Console.ReadLine();

        movieRepo.InsertMovie(movieName, movieRating, genre, ratingScale, series_or_movie);


    }
    if(userInput.ToLower() == "delete")
    {
        var movie = movieRepo.GetAllMovies();
        foreach (var mov in movie)
        {
            Console.WriteLine($"{mov.movieId} | {mov.movie_name} | {mov.rating} | {mov.genre} | {mov.rating_scale} | {mov.series_or_movie}");
            Console.WriteLine("");
        }
        Console.WriteLine("Which Movie Would You Like To Remove? Type In the MovieId");
        var x = Convert.ToInt32(Console.ReadLine());
        movieRepo.DeleteMovie(x);
    }





} while (exit == true);



