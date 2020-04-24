using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movies.Core;
using Movies.Data;

namespace MovieStoreCore.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMoviesData movieList;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Genres { get; set; }

        [BindProperty]
        public MoviesList Movies { get; set; } 
        public EditModel(IMoviesData movieList, IHtmlHelper htmlHelper)
        {
            this.movieList = movieList;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? movieId)
        {
            if (movieId.HasValue)
            {
                Movies = movieList.GetMovieById(movieId.Value);
            }
            else
            {
                Movies = new MoviesList();
            }
            
            if (Movies == null) { return RedirectToPage("./Error"); }
            Genres = htmlHelper.GetEnumSelectList<Genres>();
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Genres = htmlHelper.GetEnumSelectList<Genres>();
                return Page();
            }

            if (Movies.Id > 0)
            {
                movieList.Update(Movies);
            }
            else
            {
                movieList.Add(Movies);
            }
            
            movieList.Commit();
            TempData["Message"] = "Saved Successfully !";
            return RedirectToPage("./Details", new { movieId = Movies.Id });

        }
    }
}