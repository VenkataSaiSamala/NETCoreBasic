using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Core
{
    public class MoviesList
    {
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string Country { get; set; }
        public Genres Genres { get; set; }
    }
}
