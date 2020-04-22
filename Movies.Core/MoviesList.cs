using System;

namespace Movies.Core
{
    public class MoviesList
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Country { get; set; }
        public Genres Genres { get; set; }
    }
}
