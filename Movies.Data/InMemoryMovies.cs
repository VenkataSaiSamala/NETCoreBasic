using System.Collections.Generic;
using Movies.Core;
using System.Linq;

namespace Movies.Data
{
    public class InMemoryMovies : IMoviesData
    {
        readonly List<MoviesList> moviesLists;

        public InMemoryMovies()
        {
            moviesLists = new List<MoviesList>()
            {
                new MoviesList { Id= 1, Country="USA", Genres = Genres.Drama, MovieName="Shawnshak Redemption"},
                new MoviesList { Id= 2, Country="India", Genres = Genres.Sports, MovieName="Bhaag Milkha Bhaag"},
                new MoviesList { Id= 3, Country="South Korea", Genres = Genres.Thriller, MovieName="Parasite"}
            };
        }

        public MoviesList Add(MoviesList moviesList)
        {
            moviesLists.Add(moviesList);
            moviesList.Id = moviesLists.Max(s => s.Id) + 1;
            return moviesList;
        }

        public int Commit()
        {
            return 0;
        }

        public MoviesList Delete(int id)
        {
            var movie = moviesLists.SingleOrDefault(s => s.Id == id);
            if (movie != null)
            {
                moviesLists.Remove(movie);
            }
            return movie;

        }

        public IEnumerable<MoviesList> GetAll()
        {
            return from m in moviesLists
                   orderby m.Id
                   select m;
        }

        public MoviesList GetMovieById(int id)
        {
            return moviesLists.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<MoviesList> GetMovieByName(string name = null)
        {
            return from m in moviesLists
                   where string.IsNullOrEmpty(name) || m.MovieName.StartsWith(name)
                   orderby m.Id
                   select m;
        }

        public MoviesList Update(MoviesList moviesList)
        {
            var movie = moviesLists.SingleOrDefault(s => s.Id == moviesList.Id);
            if(movie != null)
            {
                movie.MovieName = moviesList.MovieName;
                movie.Country = moviesList.Country;
                movie.Genres = moviesList.Genres;
            }
            return movie;
        }

    }
}
