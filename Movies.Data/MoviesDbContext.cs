using Microsoft.EntityFrameworkCore;
using Movies.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }
        
        public DbSet<MoviesList> MoviesList { get; set; }
    }
}
