using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Movies.Data;
using Movies.Core;

namespace MovieStoreCore.Pages.Movies
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMoviesData movieData;
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public IEnumerable<MoviesList> moviesData { get; set; }

        public string Message { get; set; }
        public ListModel(IConfiguration config, IMoviesData movieData)
        {
            this.config = config;
            this.movieData = movieData;
        }
        public void OnGet()
        {
            moviesData = movieData.GetMovieByName(SearchTerm);
        }
    }
}