using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        void InsertMovie(int movieid, string movie_name, string rating, string genre, int rating_scale, string movie_or_series);
        void DeleteMovie(int movieid);
    }
}
