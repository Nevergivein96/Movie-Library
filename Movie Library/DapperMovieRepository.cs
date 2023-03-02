using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void InsertMovie(int movieid, string movie_name, string rating, string genre, int rating_scale, string movie_or_series)
        {
            throw new NotImplementedException();
        }
        public void DeleteMovie(int movieid)
        {
            throw new NotImplementedException();
        }
    }
}
