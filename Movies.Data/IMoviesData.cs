using System.Collections.Generic;
using System.Text;
using Movies.Core;

namespace Movies.Data
{
    public interface IMoviesData
    {
        IEnumerable<MoviesList> GetMovieByName(string name);
        MoviesList GetMovieById(int id);
        MoviesList Add(MoviesList moviesList);
        MoviesList Update(MoviesList moviesList);
        MoviesList Delete(int id);
        int Commit();
    }
}
