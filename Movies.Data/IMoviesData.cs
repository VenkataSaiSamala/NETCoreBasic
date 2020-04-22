﻿using System;
using System.Collections.Generic;
using System.Text;
using Movies.Core;
using System.Linq;

namespace Movies.Data
{
    public interface IMoviesData
    {
        IEnumerable<MoviesList> GetAll();
    }

    public class InMemoryMovies : IMoviesData
    {
        readonly List<MoviesList> moviesList;

        public InMemoryMovies()
        {
            moviesList = new List<MoviesList>()
            {
                new MoviesList { Id= 1, Country="USA", Genres = Genres.Drama, MovieName="Shawnshak Redemption"},
                new MoviesList { Id= 2, Country="India", Genres = Genres.Sports, MovieName="Bhaag Milkha Bhaag"},
                new MoviesList { Id= 3, Country="South Korea", Genres = Genres.Thriller, MovieName="Parasite"}
            };
        }
        public IEnumerable<MoviesList> GetAll()
        {
            return from m in moviesList
                   orderby m.Id
                   select m;
        }
    }
}