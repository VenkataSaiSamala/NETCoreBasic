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
    public class DeleteModel : PageModel
    {
        private readonly IMoviesData moviesData;

        public MoviesList Movies { get; set; }

        public DeleteModel(IMoviesData movieData)
        {
            this.moviesData = movieData;
        }

        public IActionResult OnGet(int movieId)
        {
            Movies = moviesData.GetMovieById(movieId);
            if(Movies == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int movieId)
        {
            Movies = moviesData.Delete(movieId);
            moviesData.Commit();
            if (Movies == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = "Deleted Successfully";
            return RedirectToPage("./List");
        }
    }
}