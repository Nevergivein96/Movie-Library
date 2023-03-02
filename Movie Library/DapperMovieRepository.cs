using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movie_Library
{
    public class DapperMovieRepository : IMovieRepository
    {
        private readonly IDbConnection _conn;
        public DapperMovieRepository(IDbConnection conn)
        {
            _conn = conn;
        }       

        public IEnumerable<Movie> GetAllMovies()
        {
            return _conn.Query<Movie>("select * from movie_library");
        }

        public void InsertMovie(string movie_name, string rating, string genre, int rating_scale, string series_or_movie)
        {
            _conn.Execute("insert into movie_library (movie_name, rating, genre, rating_scale, series_or_movie) values (@movie_name, @rating, @genre, @rating_scale, @series_or_movie) ",
                new { movie_name = movie_name, rating = rating, genre = genre, rating_scale =rating_scale, series_or_movie = series_or_movie});
        }

        public void DeleteMovie(int movieid)
        {
            _conn.Execute("DELETE FROM movie_library WHERE movieid = @movieid;",
               new { movieid = movieid });
        }
    }
       
    
}
