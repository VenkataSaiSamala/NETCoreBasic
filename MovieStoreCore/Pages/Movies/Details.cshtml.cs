using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Movies.Core;
using Movies.Data;

namespace MovieStoreCore.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly IMoviesData _moviesData;
        public MoviesList MoviesList { get; set; }

        public DetailsModel(IMoviesData moviesData)
        {
            this._moviesData = moviesData;
        }

        public IActionResult OnGet(int movieID)
        {
            MoviesList = _moviesData.GetMovieById(movieID);
            if (MoviesList == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }
    }
}