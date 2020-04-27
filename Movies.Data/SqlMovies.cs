using System;
using System.Collections.Generic;
using Movies.Core;
using System.Linq;

namespace Movies.Data
{
    public class SqlMovies : IMoviesData
    {
        private readonly MoviesDbContext moviesDbContext;

        public SqlMovies(MoviesDbContext moviesDbContext)
        {
            this.moviesDbContext = moviesDbContext;
        }

        public MoviesList Add(MoviesList moviesList)
        {
            moviesDbContext.Add(moviesList);
            return moviesList;
        }

        public int Commit()
        {
            return moviesDbContext.SaveChanges();
        }

        public MoviesList Delete(int id)
        {
            var movie = GetMovieById(id);
            if (movie != null)
            {
                moviesDbContext.Remove(movie);
            }
            return movie;
        }

        public MoviesList GetMovieById(int id)
        {
            var movie = moviesDbContext.MoviesList.Find(id);
            return movie;
        }

        public IEnumerable<MoviesList> GetMovieByName(string name)
        {
            var query = from m in moviesDbContext.MoviesList
                   where string.IsNullOrEmpty(name) || m.MovieName.StartsWith(name)
                   orderby m.Id
                   select m;
            return query;
        }

        public MoviesList Update(MoviesList moviesList)
        {
            var entity = moviesDbContext.MoviesList.Attach(moviesList);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return moviesList;

        }
    }
}
