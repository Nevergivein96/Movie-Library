using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Library
{
    public class Movie
    {
        public int movieId { get; set; }
        public string movie_name { get; set; }
        public string rating { get; set;}
        public string genre { get; set;}
        public int rating_scale { get; set;}
        public string series_or_movie { get; set;}
    }
}
